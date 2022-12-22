using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class RotateInRotatePoint : MonoBehaviour
{
    //goc quay hien tai
    Vector3 curentEulerAngles;
    public float RotateSpeed = 60;
    void Update()
    {
        // transform.localEulerAngles: Phep quay quanh truc Z
        //Mathf.PingPong: tra ve gia tri giua 0 va length
        //120 la goc xoay
        //-60 so voi truc x
        transform.localEulerAngles = new Vector3(0,0,Mathf.PingPong(Time.time*RotateSpeed,120)-60);
       // Debug.Log(Mathf.PingPong(Time.time * RotateSpeed, 90) - 45);
    }
}
