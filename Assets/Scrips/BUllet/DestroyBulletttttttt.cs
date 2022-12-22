using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBull : MonoBehaviour
{
    GameObject obj;
    public float timeDestroy=2f;
    void Start()
    {
        obj = gameObject;
        Destroy(obj, timeDestroy);
    }
}
