using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject enemy; // prefab으로 만든 적을 가져옴

    public float minX = -2.5f; // 랜덤한 위치의 최소 X 값
    public float maxX = 2.5f; // 랜덤한 위치의 최대 X 값
    public float minY = 5f; // 랜덤한 위치의 최소 Y 값
    public float maxY = 4f; // 랜덤한 위치의 최대 Y 값

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, 1f); // 일정 간격으로 SpawnEnemy 함수를 호출
    }

    void SpawnEnemy()
    {
        // 랜덤한 위치 계산
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        if(enableSpawn)
        {
            // 적 생성
            Vector3 randomPosition = new Vector3(randomX, randomY, 0);
            Instantiate(enemy, randomPosition, Quaternion.identity);
        }

    }

    private void Update()
    {

    }
}