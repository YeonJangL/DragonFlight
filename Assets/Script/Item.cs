using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float ItemVelocity = 20f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0));
    }

    private void Update()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
