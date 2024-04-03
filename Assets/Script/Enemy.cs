using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 움직일 속도를 지정해 줌
    public float moveSpeed = 1.3f;

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
        // 움직임 변수로 만들기
        float distanceY = moveSpeed * Time.deltaTime;
        // 움직임을 반영
        transform.Translate(0, -distanceY, 0);               
    }

    // 화면 밖으로 나가면 카메라에서 안보이면
    private void OnBecameInvisible()
    {
        Destroy(gameObject); // 객체 삭제        
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