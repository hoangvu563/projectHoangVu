using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MoveSpeedBullet = 5f;
    Vector2 Target;
    Transform Player;
    public GameObject EplodeBulletBoss;
    //public GameObject enemy;
    public float moveSpeed = 10f;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Target = new Vector3(Player.position.x, Player.position.y, Player.position.z);   
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, MoveSpeedBullet * Time.deltaTime);
        if (transform.position.x == Target.x && transform.position.y == Target.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        var a = Instantiate(EplodeBulletBoss, transform.position, Quaternion.identity);
        Destroy(a, 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
