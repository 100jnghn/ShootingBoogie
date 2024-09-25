using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    [Header ("----- Detecting Objects -----")]
    public bool enemy;
    public bool bullet;

    // bullet �浹 ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (bullet)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    // enemy �浹 ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (enemy)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
