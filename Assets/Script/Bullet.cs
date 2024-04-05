using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public GameObject explosion;
    public int Attack = 10;

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

        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // ���� ����Ʈ
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            /*// ������ ���� ��ġ
            Vector3 itemSpawnPoint = collision.gameObject.transform.position;*/

            /*// �� �����
            Destroy(collision.gameObject);*/

            /*// ������ ����
            SpawnItem spawnitem = collision.gameObject.GetComponent<SpawnItem>();
            if (spawnitem != null)
            {
                spawnitem._SpawnItem(itemSpawnPoint);
            }*/


            // ����
            SoundManager.instance.SoundDie();

            /*// ����
            GameManager.Instance.AddScore(50);

            // ���
            GameManager.Instance.AddGold(1);*/

            /*// DestroyEnemy ȣ��
            collision.gameObject.GetComponent<Enemy>().DestroyEnemy();*/

            // �̻��� �ڽ� �����
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy1"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // ���� ����Ʈ
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            // ����
            SoundManager.instance.SoundDie();

            /*// ����
            GameManager.Instance.AddScore(100);

            // ���
            GameManager.Instance.AddGold(1);*/

            // �̻��� �ڽ� �����
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy2"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // ���� ����Ʈ
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            // ����
            SoundManager.instance.SoundDie();

            /*// ����
            GameManager.Instance.AddScore(150);

            // ���
            GameManager.Instance.AddGold(1);*/

            // �̻��� �ڽ� �����
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy3"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            // ���� ����Ʈ
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            // ����
            SoundManager.instance.SoundDie();

            /*// ����
            GameManager.Instance.AddScore(200);

            // ���
            GameManager.Instance.AddGold(1);*/

            // �̻��� �ڽ� �����
            Destroy(gameObject);
        }
    }
}
