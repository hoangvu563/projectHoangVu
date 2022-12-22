using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadCOntroller : MonoBehaviour
{
    public float fall = 5;
    public Transform pointdown;
    bool isGround;
    public LayerMask groundMask;
    Rigidbody2D rb;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGround = Physics2D.OverlapBox(pointdown.position, new Vector2(0.5f, 0.23f), 0, groundMask);


        if (isGround)
        {
           
            rb.gravityScale =-0.5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.gravityScale = fall;
    }

}

