using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float bounceForce = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Random.insideUnitCircle.normalized * moveSpeed;
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 벽에 충돌하면 튕김
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 reflectDirection = Vector3.Reflect(transform.up, collision.contacts[0].normal);
            GetComponent<Rigidbody>().velocity = reflectDirection * bounceForce;
        }

        // 플레이어랑 충돌하면 골드 카운트
        else if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddGold(1);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
