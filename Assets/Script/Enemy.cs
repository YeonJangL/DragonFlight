using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy   : MonoBehaviour
{
    // ������ �ӵ��� ������ ��
    public float moveSpeed = 1.3f;

    // ���� ������ ȿ����
    public AudioClip dieClip;

    private static AudioSource dieSource;

    public GameObject destroyEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject audioObj = new GameObject("dieAudioSource");
        dieSource = audioObj.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ������ �����
        float distanceY = moveSpeed * Time.deltaTime;
        // �������� �ݿ�
        transform.Translate(0, -distanceY, 0);               
    }

    // ȭ�� ������ ������ ī�޶󿡼� �Ⱥ��̸�
    private void OnBecameInvisible()
    {
        // ����� ���
        //dieSource.PlayOneShot(dieClip);

        Destroy(gameObject); // ��ü ����

        destroyEffectPrefab.SetActive(true);
    }
}