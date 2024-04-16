using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float spawnRaze = 1;
    List<ObjectPool<GameObject>> pools;
    float spawnTimer = 0;
    private void Awake()
    {
        pools = new List<ObjectPool<GameObject>>();
        foreach (GameObject prefab in enemyPrefabs)
        {
            ObjectPool<GameObject> pool = new(() => Instantiate(prefab),
                ActionOnGet, ActionOnRelease, ActionOnDestroy,
                collectionCheck: true, defaultCapacity: 100, maxSize: 1000);
            pools.Add(pool);
        }
    }

    private void ActionOnGet(GameObject obj)
    {
        if (obj.TryGetComponent(out EnemyBase enemy))
        {
            enemy.ResetNewEnemy(transform.position);
        }
        obj.transform.parent = transform;
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

    void SpawnEnemy()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer < spawnRaze) return;
        spawnTimer = 0;

        int index = Random.Range(0, pools.Count);
        GameObject enemyClone = pools[index].Get();
        if (enemyClone.TryGetComponent(out EnemyBase enemy))
        {
            enemy.refPool ??= pools[index];
        }
    }
}
