using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // �迭
    //ArrayList arrayList = new ArrayList();
    //List<string> list = new List<string>();

    // �ڷᱸ��
    public List<GameObject> list = new List<GameObject>();
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        /*arrayList.Add(1);
        arrayList.Add(2);
        arrayList.Add(3);
        arrayList.Add("�����ٶ�");
        arrayList.Add(4.5f);

        arrayList[4] = 5;

        for (int i = 0; i < arrayList.Count; i++)
        {
            Debug.Log(arrayList[i]);
        }*/
        /*list.Add("�ȳ�");
        list.Add("���ɺ�ġ");

        print(list[0]);
        print(list[1]);*/
        /*for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i].name);
        }*/

        InvokeRepeating("SpawnEnemy", 0.5f, 2f);
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < 5; i++)
        {
            float xPos = transform.position.x + i * 1f;
            float yPos = 4.0f;

            GameObject obj = Instantiate(enemy, new Vector3(xPos, yPos), Quaternion.identity);
            list.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
