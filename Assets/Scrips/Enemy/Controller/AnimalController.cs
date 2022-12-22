using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    private int currentIndexPoints = 0;
    public float RotateOfObjaxisX;
    public float RotateOfObjaxisY;
    public float timeStopEnemy=1f;
    public float timer = 0f;
     
    public LayerMask LayerMask;
    public float maxDistance = 0;
    bool detectPlayer;
    public float followingPlayerSpeed = 2.5f;

    Animator ani;

    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        Raycastplayer();
        //neu khoang cach tu waypoint den vi tri enemy <0.1 => tang point len
        if (Vector2.Distance(waypoints[currentIndexPoints].transform.position, transform.position) < 0.1f)
        {
            //  ani.SetBool("isChase", false);
            //sau khi timer <=0 moi duoc quay dau
            if (timer <= 0)
            {
                timer = timeStopEnemy;
                currentIndexPoints++;
                // enemy quay dau---dung ham rotate
                transform.Rotate(RotateOfObjaxisX, RotateOfObjaxisY, 0);
                //neu diem point lon hon thi reset ve 0
                if (currentIndexPoints >= waypoints.Length)
                {
                    currentIndexPoints = 0;
                }
            }
            else
            {
                ani.SetBool("isChase", false);
                timer -= Time.deltaTime;
            }
        }
        else if (Vector2.Distance(waypoints[currentIndexPoints].transform.position, transform.position) > 0.1f)
        {

            ani.SetBool("isChase", true);
            //ham di chuyen tu enemy den points
            if (detectPlayer)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndexPoints].transform.position,2.5f* speed * Time.deltaTime);
            }
            else if(detectPlayer==false)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndexPoints].transform.position, speed * Time.deltaTime);
            }
        }
    }
    void Raycastplayer()
    {
        Vector2 origin = transform.position;
        Vector2 direction = transform.right * (-transform.localScale.x);
        Debug.DrawRay(origin, direction*maxDistance, Color.blue);
        detectPlayer = Physics2D.Raycast(origin, direction, maxDistance, LayerMask);
    }
}
