using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    [SerializeField] private float range = 1f;
    [SerializeField] private int totalEnemyPerSpawn = 1;

    private float spawnTime = 2f;

    private float groundStart;
    private float groundEnd;

    private void Start()
    {
        BoxCollider2D ground = GetComponent<BoxCollider2D>();
        groundStart = ground.bounds.min.x;
        groundEnd = ground.bounds.min.x;
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime < 0)
        {
            spawnTime = 2f;

            for(int i = 0; i < totalEnemyPerSpawn; i++)
            {
                float enemySpawnRange = player.transform.position.x + range;
                float enemyPos = Random.Range(-enemySpawnRange, enemySpawnRange);
            
                Debug.Log(enemyPos);

                //if(enemyPos < groundStart)
                //{
                //    enemyPos = groundStart;
                //}

                //if (enemyPos > groundEnd)
                //{
                //    enemyPos = groundEnd;
                //}

                Instantiate(enemy, new Vector2(enemyPos, 0), Quaternion.identity);
            }
        }
    }
}
