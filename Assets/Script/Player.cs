using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ���ǵ�
    public float moveSpeed = 3;
    float playerWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Player ��ü�� �ʺ� ������
        playerWidth = GetComponent<Renderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // x�� �� ���� vector ���� * �ð�  * ���ǵ�
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        /*// x�� �̵� ����
        transform.Translate(distanceX, 0, 0);*/

        // ���ο� ��ġ ���
        Vector3 newPosition = transform.position + new Vector3(distanceX, 0, 0);

        // ȭ�� ������ ������ ���ϵ��� ����
        float halfPlayerWidth = playerWidth / 2;
        float screenEdgeLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + halfPlayerWidth;
        float screenEdgeRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfPlayerWidth;
        newPosition.x = Mathf.Clamp(newPosition.x, screenEdgeLeft, screenEdgeRight);

        // ���ο� ��ġ�� �̵�
        transform.position = newPosition;
    }
}
