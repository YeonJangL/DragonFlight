using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject explosion;

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

            // �� �����
            Destroy(collision.gameObject);

            // ����
            SoundManager.instance.SoundDie();

            // ����
            GameManager.Instance.AddScore(100);

            /*// DestroyEnemy ȣ��
            collision.gameObject.GetComponent<Enemy>().DestroyEnemy();*/

            // �̻��� �ڽ� �����
            Destroy(gameObject);
        }
    }
}
