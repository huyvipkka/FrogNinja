using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<ObjectPool<GameObject>> pools;
    private void Awake()
    {
        pools = new List<ObjectPool<GameObject>>();
        Transform parentTransform = gameObject.transform;
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform childTransform = parentTransform.GetChild(i);

            ObjectPool<GameObject> pool = new(() => Instantiate(childTransform.gameObject),
                ActionOnGet, ActionOnRelease, ActionOnDestroy,
                collectionCheck: true, defaultCapacity: 100, maxSize: 1000);
            pools.Add(pool);
        }
        Debug.Log(parentTransform.childCount);
        Debug.Log(pools.Count);
    }

    private void ActionOnGet(GameObject obj)
    {
        if (obj.TryGetComponent(out EnemyBase enemy))
        {
            enemy.ResetPos(transform.position);
        }
        obj.SetActive(true);
    }

    private void ActionOnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void ActionOnDestroy(GameObject obj)
    {
        Destroy(obj);
    }

    void Update()
    {
        SpawnEnemy();
    }

    float spawnRaze = 1;
    float spawnTimer = 0;
    void SpawnEnemy()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer < spawnRaze) return;
        spawnTimer = 0;

        spawnRaze = Random.Range(0.8f, 2);
        int index = Random.Range(0, pools.Count);

        GameObject enemyClone = pools[index].Get();
        if (enemyClone.TryGetComponent(out EnemyBase enemy))
        {
            enemy.refPool = pools[index];
        }
    }
}
