using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // �̱���
    public static SoundManager instance; // �ڱ� �ڽ��� ������ ����
    // ��𼭵� ������ ��� ����

    AudioSource myAudio; // AudioSource ������Ʈ�� ������ ����

    public AudioClip soundExplosion; // ����� �Ҹ��� ������ ����
    public AudioClip soundDie; // �״� ����

    private void Awake()
    {
        if (instance == null) // instance�� ����ִ��� �˻�
        {
            instance = this; // �ڱ� ���� ��ü
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); // AudioSource ������Ʈ ��������
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
