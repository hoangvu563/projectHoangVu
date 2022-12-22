using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDamageSender : MonoBehaviour
{
    Animator ani;
    public float valuDamageOfBullet = 1;
    public GameObject ExplodeTwo;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //khi vien dan cham vao doi tuong co gan ham enemy se kich hoat
        if (collision.gameObject.TryGetComponent<AnimalTakeDamage>(out AnimalTakeDamage component))
        {
            component.Takedamage(valuDamageOfBullet);
            Instantiate(ExplodeTwo, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void bulletdestroy()
    {
        Instantiate(ExplodeTwo, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
