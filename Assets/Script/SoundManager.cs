using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 싱글톤
    public static SoundManager instance; // 자기 자신을 변수로 만듦
    // 어디서든 가져가 사용 가능

    AudioSource myAudio; // AudioSource 컴포넌트를 변수로 담음

    public AudioClip soundExplosion; // 재생할 소리를 변수로 담음
    public AudioClip soundDie; // 죽는 사운드

    private void Awake()
    {
        if (instance == null) // instance가 비어있는지 검사
        {
            instance = this; // 자기 참조 객체
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); // AudioSource 컴포넌트 가져오기
    }

    public void PlayerSound()
    {
        myAudio.PlayOneShot(soundExplosion);
    }

    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie);
    }
}
