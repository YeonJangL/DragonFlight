using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();

    public void _SpawnItem(Vector3 position)
    {
        int ran = Random.Range(0, list.Count);

        Instantiate(list[ran], position, Quaternion.identity);
    }
}
