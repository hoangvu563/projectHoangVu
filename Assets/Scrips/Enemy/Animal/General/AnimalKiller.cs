using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimalKiller : MonoBehaviour
{
    public GameObject Explode1;
    public void killler()
    {
        AudioManager.instance.Play("EnemyXplode");
        Destroy(gameObject);
    }
    public void OnDestroy()
    {
        var a = Instantiate(Explode1,transform.position,Quaternion.identity);
        Destroy(a,1f); 
        
    }
}
