using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;
    Transform player;
    public float Length = 8f;
    float timer = 0;
    public float timeDelay = 1f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > Length)
        {
        return;
        }
        else if (distance < Length)
        {
            if (timer <= 0)
            {
                timer = timeDelay;
                Instantiate(Bullet, FirePoint.position, Quaternion.identity);
            }
            else
            {
                timer-= Time.deltaTime; 
            }
        }
    }
}
