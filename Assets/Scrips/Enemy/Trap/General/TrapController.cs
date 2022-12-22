using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    private int currentIndexPoints = 0;
   
    public float timeStopEnemy=1f;
    public float timer = 0f;

    void Update()
    {
        //neu khoang cach tu waypoint den vi tri enemy <0.1 => tang point len
        if (Vector2.Distance(waypoints[currentIndexPoints].transform.position, transform.position) < 0.1f)
        {
            //sau khi timer <=0 moi duoc quay dau
            if (timer <= 0)
            {
                timer = timeStopEnemy;
                currentIndexPoints++;
                // enemy quay dau---dung ham rotate
                //neu diem point lon hon thi reset ve 0
                if (currentIndexPoints >= waypoints.Length)
                {
                    currentIndexPoints = 0;
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
            //ham di chuyen tu enemy den points
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndexPoints].transform.position, speed * Time.deltaTime);
    }
}
