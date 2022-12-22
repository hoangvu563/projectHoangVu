using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerPlantCollision : MonoBehaviour
{
    public GameObject exlode;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        var a =  Instantiate(exlode, transform.position, Quaternion.identity);
        Destroy(a, 1);
    }
}
