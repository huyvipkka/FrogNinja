using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemys;
    private void Awake()
    {
        Transform parentTransform = gameObject.transform;
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform childTransform = parentTransform.GetChild(i);
            enemys.Add(childTransform.gameObject);
        }
        Debug.Log($"enemy count: {enemys.Count}");
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
        int index = Random.Range(0, enemys.Count);

        GameObject enemyClone = Instantiate(enemys[index], transform.position, Quaternion.identity);
        enemyClone.SetActive(true);

    }
}
