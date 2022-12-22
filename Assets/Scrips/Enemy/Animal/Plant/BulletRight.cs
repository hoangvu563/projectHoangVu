using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRight : MonoBehaviour
{ Rigidbody2D rb;
    public float moveSpeed = 8;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0);
    }
}
