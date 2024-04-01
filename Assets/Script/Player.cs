using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 스피드
    public float moveSpeed = 3;
    float playerWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Player 객체의 너비를 가져옴
        playerWidth = GetComponent<Renderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // x쪽 값 설정 vector 방향 * 시간  * 스피드
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        /*// x쪽 이동 설정
        transform.Translate(distanceX, 0, 0);*/

        // 새로운 위치 계산
        Vector3 newPosition = transform.position + new Vector3(distanceX, 0, 0);

        // 화면 밖으로 나가지 못하도록 제한
        float halfPlayerWidth = playerWidth / 2;
        float screenEdgeLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + halfPlayerWidth;
        float screenEdgeRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfPlayerWidth;
        newPosition.x = Mathf.Clamp(newPosition.x, screenEdgeLeft, screenEdgeRight);

        // 새로운 위치로 이동
        transform.position = newPosition;
    }
}
