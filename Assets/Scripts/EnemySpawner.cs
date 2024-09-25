using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    [Header ("----- Spawn Time -----")]
    public float spawnTime = 2f;
    private float currenTime;

    [Header("----- Spawn Range -----")]
    public float spawnRangeY;

    void Start()
    {
        InvokeRepeating("spawnEnemy", 3f, spawnTime);
    }

    void Update()
    {
        
    }

    // 랜덤 위치에 enemy 생성
    void spawnEnemy()
    {
        float randY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(transform.position.x, randY, 0);

        Instantiate(enemy, spawnPos, Quaternion.identity);
    }
}
