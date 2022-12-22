using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
    private Transform Player;
    public float MoveSpeedBos = 2f;
    //khoang cac ma enemy phai dung lai
    public float stopDistance;
    //khoang cach ma enemy phai lui` lai
    public float retreatDistan;
    //vien dan cua Boss
    public GameObject projecttile;
    //diem ban cua enemy
    public Transform firePoint;

    private float timer;
    public float timeBetweenFire = 2f;
    private void Awake()
    {
        this.LoadComponent();
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected void Reset()
    {
        this.LoadComponent();
    }
    protected void LoadComponent()
    {
        this.loadFirePoint();
    }
    protected virtual void loadFirePoint()
    {
        if(this.firePoint!=null)return;
        this.firePoint = GameObject.FindGameObjectWithTag("FirePointBoss").transform;
    }
    
    void Update()
    {
        //neu con xa thi enemy tien lai player
        if (Vector2.Distance(transform.parent.position, Player.position) > stopDistance)
        {
            // Debug.Log("hoang");
            transform.parent.position = Vector2.MoveTowards(this.transform.parent.position, Player.position, MoveSpeedBos * Time.deltaTime);
        }
        //neu lai gan thi dung lai
        else
        {
            if (Vector2.Distance(transform.parent.position, Player.position) < stopDistance && Vector2.Distance(transform.parent.position, Player.position) > retreatDistan)
            {
                transform.parent.position = this.transform.parent.position;
            }
            else if (Vector2.Distance(transform.parent.position, Player.position) < retreatDistan)
            {
                transform.parent.position = Vector2.MoveTowards(this.transform.parent.position, Player.position, -MoveSpeedBos * Time.deltaTime);
            }
        }
        if (timer <= 0)
        {
            Instantiate(projecttile, firePoint.position, Quaternion.identity);
            timer = timeBetweenFire;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
