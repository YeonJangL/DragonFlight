using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    // 움직일 속도를 지정해 줌
    public float moveSpeed = 3f;
    public int HP = 20;

    // 아이템 가져오기
    public List<GameObject> list = new List<GameObject>();

    /*// 적이 죽을때 효과음
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
        // 아래 방향으로 움직여라
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    // 화면 밖으로 나가면 카메라에서 안보이면
    private void OnBecameInvisible()
    {
        Destroy(gameObject); // 객체 삭제        
    }

    public void Damage(int attack)
    {
        HP -= attack;
        ChangeEnemyColor();

        if (HP <= 0)
        {
            // 점수
            GameManager.Instance.AddScore(50);
            // 골드
            GameManager.Instance.AddGold(1);
            ItemDrop();
            Destroy(gameObject);
        }
    }

    private void ChangeEnemyColor()
    {
        // 적 오브젝트에서 모든 SpriteRenderer 컴포넌트를 찾아서 색상 변경
        SpriteRenderer[] renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = Color.red;
        }
    }

    public void ItemDrop()
    {
        // 아이템 랜덤 생성
        int ran = Random.Range(0, list.Count);
        /*GameObject itemToDrop = list[ran];
        Instantiate(itemToDrop, transform.position, Quaternion.identity);*/

        Instantiate(list[ran], transform.position, Quaternion.identity);
    }

    /*public void DestroyEnemy()
    {
        // 오디오 출력
        dieSource.PlayOneShot(dieClip);

        // 이펙트 생성
        GameObject effect = Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);

        // 이펙트 삭제
        Destroy(effect, 0.3f);

        // 객체 삭제
        Destroy(gameObject);
    }*/
}