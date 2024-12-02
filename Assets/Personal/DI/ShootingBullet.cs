using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed; // 투사체가 발사 방향으로 이동
    }

    // 충돌 처리
    void OnCollisionEnter(Collision collision)
    {
        // 충돌 시 처리할 내용 (예: 적에게 피해 주기)
        Destroy(gameObject); // 투사체 파괴
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // 적 태그 확인
        {
            // 적의 스크립트에서 피해를 주는 메서드 호출
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(10); // 피해량 조정
            }
        }
        Destroy(gameObject); // 투사체 파괴
    }

    public float lifeTime = 3f; // 투사체 생명 시간

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed; // 투사체가 발사 방향으로 이동
        Destroy(gameObject, lifeTime); // 일정 시간 후 투사체 파괴
    }


    public GameObject hitEffect; // 충돌 이펙트 프리팹

    void OnCollisionEnter(Collision collision)
    {
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject); // 투사체 파괴
    }

}
