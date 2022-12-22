using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOfboss : MonoBehaviour
{
    
    public float timeLive = 2;
    private void Start()
    {
        Destroy(gameObject,timeLive);
    }
    

}
