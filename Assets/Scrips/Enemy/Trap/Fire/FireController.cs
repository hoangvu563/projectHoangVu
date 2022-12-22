using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    Animator ani;
    private void Awake()
    {
        ani=GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ani.SetBool("isHit", true);
        }
    }
    //goi event trong animation
    void Onfire()
    {
        ani.SetBool("isOn", true);
        ani.SetBool("isHit", false);

    }
    //goi event trong animation
    void OffFire()
    {
        ani.SetBool("isOn", false);
    }

}
