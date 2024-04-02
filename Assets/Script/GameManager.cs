using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글톤
    public static GameManager Instance;
    public Text scoreText; // 점수를 표시하는 객체 에디터에서 받아옴
    public Text startText; // 카운트 텍스트 받아옴

    int score = 0; // 점수 관리

    private void Awake()
    {
        if (Instance == null) // null 체크
        {
            Instance = this; // 자기자신 인스턴스해서 저장
        }
    }

    public void AddScore(int num) // 점수 추가하는 함수
    {
        score += num;
        scoreText.text = "Score : " + score; // 텍스트에 반영
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        int i = 3;

        while (i > 0)
        {
            startText.text = i.ToString();
            yield return new WaitForSeconds(1);

            i--;

            if (i == 0)
            {
                startText.gameObject.SetActive(false);
            }
        }
    }
}
