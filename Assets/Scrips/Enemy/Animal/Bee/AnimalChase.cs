using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalChase : MonoBehaviour
{

    Transform Player;
    public float stopDistance = 10;
    public float speed = 2f;
    public Transform oldPosition;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        float ditance = Vector2.Distance(transform.position, Player.position);

        if (ditance < stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
        else if(ditance>stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, oldPosition.position, speed * Time.deltaTime);
        }
    }
}
