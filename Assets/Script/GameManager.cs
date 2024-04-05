using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �̱���
    public static GameManager Instance;
    public Text scoreText; // ������ ǥ���ϴ� ��ü �����Ϳ��� �޾ƿ�
    public Text startText; // ī��Ʈ �ؽ�Ʈ �޾ƿ�
    public Text goldText;
    public GameObject[] lifeObjects;
    public Button restartButton;
    public Text restartText;
    public Text goldscore;
    public Text scorescore;

    int score = 0; // ���� ����
    int gold = 0; // ��� ����
    int life = 2; // ���� ����

    private void Awake()
    {
        if (Instance == null) // null üũ
        {
            Instance = this; // �ڱ��ڽ� �ν��Ͻ��ؼ� ����
        }
    }

    public void AddGold(int num)
    {
        gold += num;
        goldText.text = gold.ToString();
    }

    public void AddScore(int num) // ���� �߰��ϴ� �Լ�
    {
        score += num;
        scoreText.text = score.ToString(); // �ؽ�Ʈ�� �ݿ�
    }

    public void Die(int num)
    {
        life -= num;
        // life ������Ʈ�� �ϳ��� ���� ��Ű�� �;�
        
        // life ��Ȱ��ȭ
        for (int i = 0; i < lifeObjects.Length; i++)
        {
            if (i < life)
            {
                // ���� ��������� Ȱ��ȭ
                lifeObjects[i].SetActive(true);
            }
            else
            {
                // ������ ������ ��Ȱ��ȭ
                lifeObjects[i].SetActive(false);
            }
        }
        if (life <= 0)
        {
            Time.timeScale = 0f; // ������ ����
            restartText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            goldscore.text = "Gold : " + gold;
            goldscore.gameObject.SetActive(true);

            scorescore.text = " Score : " + score;
            scorescore.gameObject.SetActive(true);

            // UI â���� �ٽ� ���� ��ư�� ������
            // ���� ���� �ٽ� �ε� �ϰ� �;�
            restartButton.onClick.AddListener(RestartScene);
        }
    }

    public void RestartScene()
    {
        Time.timeScale = 1f; // ���� �ٽ� ����
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
