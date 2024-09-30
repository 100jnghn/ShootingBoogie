using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform firePos;   // 투사체 생성 위치
    public GameObject bullet;   // 공격시 생성하는 투사체

    [Header("Sounds")]
    public AudioSource sfxFire;   // 공격 소리 이펙트

    [Header("----- Attack -----")]
    public float attackTime;
    private float currentTime;
    private bool isAttackable = true;

    [Header ("----- Move Range -----")]
    public float moveRangeX;
    public float moveRangeY;

    void Start()
    {
        
    }

    void Update()
    {
        checkMoveRange();
        checkAttack();
    }

    // 이동 범위 제한
    void checkMoveRange()
    {
        Vector3 posVec = new Vector3(Mathf.Clamp(transform.position.x, -moveRangeX, moveRangeX), Mathf.Clamp(transform.position.y, -moveRangeY, moveRangeY), 0);
        transform.position = posVec;
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

        Instantiate(bullet, firePos);   // bullet 생성
        sfxFire.Play();                 // sound 재생
        
        currentTime = 0;
        isAttackable = false;
    }
}
