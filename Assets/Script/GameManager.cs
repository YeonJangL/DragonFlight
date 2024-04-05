using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글톤
    public static GameManager Instance;
    public Text scoreText; // 점수를 표시하는 객체 에디터에서 받아옴
    public Text startText; // 카운트 텍스트 받아옴
    public Text goldText;
    public GameObject[] lifeObjects;
    public Button restartButton;
    public Text restartText;
    public Text goldscore;
    public Text scorescore;

    int score = 0; // 점수 관리
    int gold = 0; // 골드 관리
    int life = 2; // 생명 관리

    private void Awake()
    {
        if (Instance == null) // null 체크
        {
            Instance = this; // 자기자신 인스턴스해서 저장
        }
    }

    public void AddGold(int num)
    {
        gold += num;
        goldText.text = gold.ToString();
    }

    public void AddScore(int num) // 점수 추가하는 함수
    {
        score += num;
        scoreText.text = score.ToString(); // 텍스트에 반영
    }

    public void Die(int num)
    {
        life -= num;
        // life 오브젝트를 하나씩 감소 시키고 싶어
        
        // life 비활성화
        for (int i = 0; i < lifeObjects.Length; i++)
        {
            if (i < life)
            {
                // 현재 생명까지만 활성화
                lifeObjects[i].SetActive(true);
            }
            else
            {
                // 나머지 생명은 비활성화
                lifeObjects[i].SetActive(false);
            }
        }
        if (life <= 0)
        {
            Time.timeScale = 0f; // 게임을 멈춤
            restartText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            goldscore.text = "Gold : " + gold;
            goldscore.gameObject.SetActive(true);

            scorescore.text = " Score : " + score;
            scorescore.gameObject.SetActive(true);

            // UI 창에서 다시 시작 버튼을 누르면
            // 현재 씬을 다시 로드 하고 싶어
            restartButton.onClick.AddListener(RestartScene);
        }
    }

    public void RestartScene()
    {
        Time.timeScale = 1f; // 게임 다시 시작
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
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
