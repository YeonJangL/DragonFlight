using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour
{
    public GameObject destroyEffect;

    private void SpawnDestroyEffect()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }
}