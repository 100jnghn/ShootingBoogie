using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreValue; // 적을 처치할 때 획득하는 점수
    public float moveSpeed; // 적의 이동 속도

    private Transform player; // 플레이어의 위치 참조

    void Start()
    {
        // 플레이어 오브젝트를 찾음 (태그를 "Player"로 설정해야 함)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // 플레이어를 향해 이동
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 플레이어와 충돌했을 때 점수 누적 및 적 제거
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddScore(scoreValue); // 점수 추가
            Destroy(gameObject); // 적 제거
        }
    }
}
