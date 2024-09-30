using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform firePos;   // ����ü ���� ��ġ
    public GameObject bullet;   // ���ݽ� �����ϴ� ����ü

    [Header("Sounds")]
    public AudioSource sfxFire;   // ���� �Ҹ� ����Ʈ

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

    // �̵� ���� ����
    void checkMoveRange()
    {
        Vector3 posVec = new Vector3(Mathf.Clamp(transform.position.x, -moveRangeX, moveRangeX), Mathf.Clamp(transform.position.y, -moveRangeY, moveRangeY), 0);
        transform.position = posVec;
    }

    // ���� ���� ���� �Ǵ�
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

    // ����
    public void doFire()
    {
        if (!isAttackable)
        {
            return;
        }

        Instantiate(bullet, firePos);   // bullet ����
        sfxFire.Play();                 // sound ���
        
        currentTime = 0;
        isAttackable = false;
    }
}
