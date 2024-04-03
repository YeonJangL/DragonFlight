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
    public ItemType itemType; // �������� ����

    private Rigidbody2D rb;
    private Vector2 moveDirection; // �������� �̵� ����

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // �������� �̵� ������ �����ϰ� ����
        moveDirection = new Vector2(Random.Range(-1f, 1f), -1f).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �浹�ϸ� ƨ��
        if (collision.gameObject.CompareTag("Wall"))
        {
            // �������� �ӵ��� x�� ��ȣ�� �ݴ�� ����
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }

        // �÷��̾�� �浹�ϸ� ��� ī��Ʈ
        else if (collision.gameObject.CompareTag("Player"))
        {
            // �������� ������ ���� ��带 ������Ŵ
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
        // �������� ������ ���� ��� �������� ��ȯ
        switch (itemType)
        {
            case ItemType.Item1:
                return 10; // Item1�� ��� 10��� ����
            case ItemType.Item2:
                return 20; // Item2�� ��� 20��� ����
            case ItemType.Item3:
                return 30; // Item3�� ��� 30��� ����
            case ItemType.Item4:
                return 40; // Item4�� ��� 40��� ����
            default:
                return 0; // �� ���� ��� ��� ���� ����
        }
    }
}