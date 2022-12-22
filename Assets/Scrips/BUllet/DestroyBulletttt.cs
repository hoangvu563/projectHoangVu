using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletttt : MonoBehaviour
{
    public float TimeDestroyBullet=2f;
    public GameObject eplodeTow;

    private void Start()
    {
        Destroy(gameObject, TimeDestroyBullet);
    }
    private void OnDestroy()
    {
        Instantiate(eplodeTow, transform.position, Quaternion.identity);
    }
}
