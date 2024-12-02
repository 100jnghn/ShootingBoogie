using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f; // 투사체 생명 시간
    public GameObject hitEffect; // 충돌 이펙트 프리팹
    public AudioSource hitSound; // 충돌 사운드

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed; // 투사체가 발사 방향으로 이동
        Destroy(gameObject, lifeTime); // 일정 시간 후 투사체 파괴
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (hitSound != null)
        {
            hitSound.Play(); // 충돌 사운드 재생
        }

        if (collision.gameObject.CompareTag("Enemy")) // 적 태그 확인
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                //enemy.TakeDamage(10); // 피해량 조정
            }
        }

        Destroy(gameObject); // 투사체 파괴
    }

    public void Initialize(Vector3 direction)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * speed; // 주어진 방향으로 이동
    }
}
