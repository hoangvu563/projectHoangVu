using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Speed = 2f;
    Rigidbody2D rb;
    public GameObject explode;
    private void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-Speed, 0);
        Destroy(gameObject, 2f);
        var a = Instantiate(explode,transform.position, Quaternion.identity);
        Destroy(a, 1);
    }
}
