using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("animalTrap"))
        {
            destroy();
        }
    }
    public void destroy()
    {
        var component = gameObject.GetComponent<AnimalKiller>();
        component.killler();
        component.OnDestroy();
    }
}
