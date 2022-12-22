using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageSender : MonoBehaviour
{
    public float valueDamage = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerTakeDamage>(out PlayerTakeDamage component))
        {
            component.takeDamageOfPlayer(valueDamage);
        }
    }
}
