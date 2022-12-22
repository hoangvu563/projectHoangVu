using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStatic : MonoBehaviour
{
    Animator ani;
    Rigidbody2D rb;
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();  
        ani= GetComponent<Animator>();  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ani.SetBool("isOn", true);
            rb.gravityScale = 2;
            Destroy(gameObject, 3);
        }
    }
}
