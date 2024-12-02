using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDI : MonoBehaviour
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
}
