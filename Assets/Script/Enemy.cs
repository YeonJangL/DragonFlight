using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    // ������ �ӵ��� ������ ��
    public float moveSpeed = 3f;
    public int HP = 20;

    // ������ ��������
    public List<GameObject> list = new List<GameObject>();

    /*// ���� ������ ȿ����
    public AudioClip dieClip;

    private static AudioSource dieSource;

    public GameObject destroyEffectPrefab;*/

    // Start is called before the first frame update
    void Start()
    {
        /*GameObject audioObj = new GameObject("dieAudioSource");
        dieSource = audioObj.AddComponent<AudioSource>();*/
    }

    // Update is called once per frame
    void Update()
    {
        // �Ʒ� �������� ��������
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    // ȭ�� ������ ������ ī�޶󿡼� �Ⱥ��̸�
    private void OnBecameInvisible()
    {
        Destroy(gameObject); // ��ü ����        
    }

    public void Damage(int attack)
    {
        HP -= attack;
        ChangeEnemyColor();

        if (HP <= 0)
        {
            // ����
            GameManager.Instance.AddScore(50);
            // ���
            GameManager.Instance.AddGold(1);
            ItemDrop();
            Destroy(gameObject);
        }
    }

    private void ChangeEnemyColor()
    {
        // �� ������Ʈ���� ��� SpriteRenderer ������Ʈ�� ã�Ƽ� ���� ����
        SpriteRenderer[] renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = Color.red;
        }
    }

    public void ItemDrop()
    {
        // ������ ���� ����
        int ran = Random.Range(0, list.Count);
        /*GameObject itemToDrop = list[ran];
        Instantiate(itemToDrop, transform.position, Quaternion.identity);*/

        Instantiate(list[ran], transform.position, Quaternion.identity);
    }

    /*public void DestroyEnemy()
    {
        // ����� ���
        dieSource.PlayOneShot(dieClip);

        // ����Ʈ ����
        GameObject effect = Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);

        // ����Ʈ ����
        Destroy(effect, 0.3f);

        // ��ü ����
        Destroy(gameObject);
    }*/
}