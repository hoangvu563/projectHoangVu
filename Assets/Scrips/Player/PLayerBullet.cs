using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PLayerBullet : MonoBehaviour
{
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    public float MoveSpeed = 2f;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //LAY HUONG CHO VIEN DAN
        Vector3 Direction = mousePosition - transform.position;
        Vector3 Rotaion = transform.position-mousePosition;
        //NORMALIZED TRA VE VEC TO CHUAN HOA CO VALUE=1;
        rb.velocity = new Vector2(Direction.x, Direction.y).normalized * MoveSpeed;
        float rot=Mathf.Atan2(Rotaion.y,Rotaion.x)*Mathf.Rad2Deg-90f;
        transform.rotation  =Quaternion.Euler(0,0,rot);
    }

    
}
