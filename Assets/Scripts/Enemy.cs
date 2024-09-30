using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �ı� �� ����Ǵ� ���� ��ƼŬ
    public GameObject smokeParticle;

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

    // ó�� ������ �� �̵� ������ ����
    void setDirection()
    {
        moveVec = target.position - transform.position;
        moveVec.Normalize();
    }

    // ������ �������� �̵���Ŵ
    void moveToPlayer()
    {
        transform.Translate(moveVec * Time.deltaTime * moveSpeed);
    }

    // bullet �浹 ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // bullet�� �浹 �� bullet�� �ڱ� �ڽ� �ı�
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // ��ƼŬ ����, ���
            GameObject particle = Instantiate(smokeParticle, transform.position, Quaternion.identity);
            ParticleSystem ps = particle.GetComponent<ParticleSystem>();
            ps.Play();

            // ��ƼŬ ��� �Ŀ� �ı�
            Destroy(particle, ps.main.duration);

            // bullet�� enemy ��� ����
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // ���� ����
            gameManager.scoreUp(1);
        }
    }

    // player �浹 ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // player�� �浹 �� ���� ����
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy Player �浹");

            // ���� ���� ���� ȣ��
            gameManager.gameEnd();
        }
    }
}
