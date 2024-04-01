using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // ��ũ���� �Ǵ� ��׶���
    public float scrollSpeed = 1f;
    private Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        // ���͸��� ������ ����
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ���͸��󿡼� ��������
        Vector2 newOffset = myMaterial.mainTextureOffset;

        // ���Ӱ� offset �ٲ��ֱ�
        // y�κ� ���� �ӵ��� ������ �����ؼ� ������
        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime));

        // ���͸��� �����¿� ���� �־���
        myMaterial.mainTextureOffset = newOffset;
    }
}
