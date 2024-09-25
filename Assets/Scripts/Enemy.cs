using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    Transform target;
    Vector2 moveVec;

    public float moveSpeed = 1f;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        setDirection();
    }

    void Update()
    {
        moveToPlayer();
    }

    // 처음 생성될 때 이동 방향을 정함
    void setDirection()
    {
        moveVec = target.position - transform.position;
        moveVec.Normalize();
    }

    // 지정한 방향으로 이동시킴
    void moveToPlayer()
    {
        transform.Translate(moveVec * Time.deltaTime * moveSpeed);
    }

    // bullet 충돌 감지
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // bullet과 충돌 시 bullet과 자기 자신 파괴
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // 점수 증가
            gameManager.scoreUp(1);
        }
    }

    // player 충돌 감지
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // player와 충돌 시 게임 종료
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy Player 충돌");

            // 게임 종료 로직 호출
            gameManager.gameEnd();
        }
    }
}
