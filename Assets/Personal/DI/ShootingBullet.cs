using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f; // 투사체 생명 시간
    public GameObject hitEffect; // 충돌 이펙트 프리팹
    public AudioSource hitSound; // 충돌 사운드
    public int damage = 10; // 피해량
    public Color warningColor = Color.red; // 경고 색상
    private Renderer bulletRenderer;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed; // 투사체가 발사 방향으로 이동
        bulletRenderer = GetComponent<Renderer>(); // Renderer 컴포넌트 가져오기
        Destroy(gameObject, lifeTime); // 일정 시간 후 투사체 파괴
    }

    void Update()
    {
        // 생명 시간이 다 되어 가면 색상 변화
        if (bulletRenderer != null)
        {
            float timeLeft = lifeTime - Time.time;
            if (timeLeft < 1f) // 남은 시간이 1초 이하일 때
            {
                bulletRenderer.material.color = warningColor; // 색상 변화
            }
        }
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
                //enemy.TakeDamage(damage); // 피해량 적용
            }
        }

        // 화면 진동 기능 (예시)
        StartCoroutine(CameraShake()); // 충돌 시 화면 진동 시작

        Destroy(gameObject); // 투사체 파괴
    }

    public void Initialize(Vector3 direction)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * speed; // 주어진 방향으로 이동
        transform.rotation = Quaternion.LookRotation(direction); // 발사 방향으로 회전
    }

    private IEnumerator CameraShake()
    {
        // 간단한 화면 진동 구현
        Vector3 originalPosition = Camera.main.transform.position;
        for (float i = 0; i < 0.1f; i += Time.deltaTime)
        {
            Vector3 randomPoint = originalPosition + Random.insideUnitSphere * 0.1f;
            Camera.main.transform.position = new Vector3(randomPoint.x, originalPosition.y, randomPoint.z);
            yield return null;
        }
        Camera.main.transform.position = originalPosition; // 원래 위치로 되돌리기
    }
}
