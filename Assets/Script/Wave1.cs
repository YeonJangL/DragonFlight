using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour
{
    // 자료 구조
    public List<GameObject> list = new List<GameObject>();

    public void SpawnEnemy()
    {
        int ran = Random.Range(0, list.Count);

        Instantiate(list[ran], list[ran].transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
