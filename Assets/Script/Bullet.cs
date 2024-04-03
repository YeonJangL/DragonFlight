using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public GameObject explosion;
    private bool isItemSpawn = false; // �������� �����Ǿ����� ���θ� ��Ÿ���� ����

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // y �� �̵�
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    // ȭ�� ������ ������ �Ⱥ��� ��� ȣ��Ǵ� �Լ�
    private void OnBecameInvisible()
    {
        // �̻��� ����
        Destroy(gameObject);
    }

    // Ʈ����
    // �ݸ���
    // enter 1�� ���ö�
    // stay ��� �浹 �����ȿ�
    // exit �浹 ������ �������� 1��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �̻��ϰ� ���� �ε���
        // if (collision.gameObject.tag == "Enemy") -> �̰� ���� �Ʒ��Ű� �� ������

        if (collision.gameObject.CompareTag("Enemy"))
        {

            // ���� ����Ʈ
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            // ������ ���� ��ġ
            Vector3 itemSpawnPoint = collision.gameObject.transform.position;

            // �� ���� ���������� ����
            ChangeEnemyColor(collision.gameObject);

            // �� �����
            Destroy(collision.gameObject, 0.5f);

            if (!isItemSpawn)
            { 
                // ������ ����
                SpawnItem spawnitem = collision.gameObject.GetComponent<SpawnItem>();
                if (spawnitem != null)
                {
                    spawnitem._SpawnItem(itemSpawnPoint);
                }
                isItemSpawn = true;
            }

            // ����
            SoundManager.instance.SoundDie();

            // ����
            GameManager.Instance.AddScore(100);

            // ���
            GameManager.Instance.AddGold(1);

            /*// DestroyEnemy ȣ��
            collision.gameObject.GetComponent<Enemy>().DestroyEnemy();*/

            // �̻��� �ڽ� �����
            Destroy(gameObject);
        }
    }
    private void ChangeEnemyColor(GameObject enemy)
    {
        // �� ������Ʈ���� ��� SpriteRenderer ������Ʈ�� ã�Ƽ� ���� ����
        SpriteRenderer[] renderers = enemy.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = Color.red;
        }
    }

}
