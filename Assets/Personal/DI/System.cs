using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDI : MonoBehaviour
{
public Transform firePos;   // 투사체 생성 위치
public GameObject bullet;    // 공격시 생성하는 투사체
public AudioSource sfxFire;  // 공격 소리 이펙트

[Header("----- Attack -----")]
public float attackTime = 1f;
private float currentTime;
private bool isAttackable = true;

// Start is called before the first frame update
void Start()
{
    
}

// Update is called once per frame
void Update()
{
    checkAttack();

    // 입력 처리
    if (Input.GetButtonDown("Fire1")) // 기본적으로 좌클릭에 바인딩
    {
        doFire();
    }
}

// 공격 가능 상태 판단
void checkAttack()
{
    if (!isAttackable)
    {
        currentTime += Time.deltaTime;

        if (currentTime >= attackTime)
        {
            isAttackable = true;
        }
    }
}

// 공격
public void doFire()
{
    if (!isAttackable)
    {
        return;
    }

    Instantiate(bullet, firePos.position, firePos.rotation);   // bullet 생성
    sfxFire.Play();                 // sound 재생
    
    currentTime = 0;
    isAttackable = false;
}
}