using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class ZombieLocalScale : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.eulerAngles= new Vector3(0,-180,0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
    }
    
}
