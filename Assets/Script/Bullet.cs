using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public GameObject explosion;
    private bool isItemSpawn = false; // 아이템이 생성되었는지 여부를 나타내는 변수

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // y 축 이동
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    // 화면 밖으로 나가면 안보일 경우 호출되는 함수
    private void OnBecameInvisible()
    {
        // 미사일 제거
        Destroy(gameObject);
    }

    // 트리거
    // 콜리젼
    // enter 1번 들어올때
    // stay 계속 충돌 범위안에
    // exit 충돌 끝날때 나가질때 1번

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 미사일과 적이 부딪힘
        // if (collision.gameObject.tag == "Enemy") -> 이거 보다 아래거가 더 안전함

        if (collision.gameObject.CompareTag("Enemy"))
        {

            // 폭발 이펙트
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 0.3f);

            // 아이템 생성 위치
            Vector3 itemSpawnPoint = collision.gameObject.transform.position;

            // 적 색상 빨간색으로 변경
            ChangeEnemyColor(collision.gameObject);

            // 적 지우기
            Destroy(collision.gameObject, 0.5f);

            if (!isItemSpawn)
            { 
                // 아이템 생성
                SpawnItem spawnitem = collision.gameObject.GetComponent<SpawnItem>();
                if (spawnitem != null)
                {
                    spawnitem._SpawnItem(itemSpawnPoint);
                }
                isItemSpawn = true;
            }

            // 사운드
            SoundManager.instance.SoundDie();

            // 점수
            GameManager.Instance.AddScore(100);

            // 골드
            GameManager.Instance.AddGold(1);

            /*// DestroyEnemy 호출
            collision.gameObject.GetComponent<Enemy>().DestroyEnemy();*/

            // 미사일 자신 지우기
            Destroy(gameObject);
        }
    }
    private void ChangeEnemyColor(GameObject enemy)
    {
        // 적 오브젝트에서 모든 SpriteRenderer 컴포넌트를 찾아서 색상 변경
        SpriteRenderer[] renderers = enemy.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = Color.red;
        }
    }

}
