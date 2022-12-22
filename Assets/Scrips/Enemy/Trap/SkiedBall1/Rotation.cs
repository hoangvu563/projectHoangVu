using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float Speed = 2;
   
    void Update()
    {
        transform.Rotate(0,0,Speed*360*Time.deltaTime);
    }
}
