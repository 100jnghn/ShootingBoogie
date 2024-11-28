using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 적 프리팹 배열 (다섯 가지)
    public Vector3 spawnAreaCenter;   // 스폰 영역의 중심
    public Vector3 spawnAreaSize;     // 스폰 영역의 크기
    public float spawnInterval = 2f;  // 적 생성 간격

    void Start()
    {
        // 적 생성 루틴 시작
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // 적 생성
            SpawnEnemy();

            // 생성 간격 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        // 스폰 위치 계산
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2),
            spawnAreaCenter.y,
            Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2)
        );

        // 랜덤한 적 프리팹 선택
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);

        // 적의 이동 속도와 점수 값을 동적으로 설정 (프리팹마다 고유한 값으로 설정 가능)
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.moveSpeed = Random.Range(3f, 8f); // 이동 속도 랜덤 설정
        }
    }

    // 스폰 영역을 씬에서 시각적으로 확인
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
    }
}
