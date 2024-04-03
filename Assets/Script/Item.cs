using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item1,
    Item2,
    Item3,
    Item4
}

public class Item : MonoBehaviour
{
    public float moveSpeed = 3f;
    public ItemType itemType; // 아이템의 종류

    private Rigidbody2D rb;
    private Vector2 moveDirection; // 아이템의 이동 방향

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 아이템의 이동 방향을 랜덤하게 설정
        moveDirection = new Vector2(Random.Range(-1f, 1f), -1f).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 벽에 충돌하면 튕김
        if (collision.gameObject.CompareTag("Wall"))
        {
            // 아이템의 속도의 x값 부호를 반대로 변경
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }

        // 플레이어랑 충돌하면 골드 카운트
        else if (collision.gameObject.CompareTag("Player"))
        {
            // 아이템의 종류에 따라 골드를 증가시킴
            int goldIncreaseAmount = GetGold();
            GameManager.Instance.AddGold(goldIncreaseAmount);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private int GetGold()
    {
        // 아이템의 종류에 따라 골드 증가량을 반환
        switch (itemType)
        {
            case ItemType.Item1:
                return 10; // Item1의 경우 10골드 증가
            case ItemType.Item2:
                return 20; // Item2의 경우 20골드 증가
            case ItemType.Item3:
                return 30; // Item3의 경우 30골드 증가
            case ItemType.Item4:
                return 40; // Item4의 경우 40골드 증가
            default:
                return 0; // 그 외의 경우 골드 증가 없음
        }
    }
}