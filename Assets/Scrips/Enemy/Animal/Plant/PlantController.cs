using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public Transform PlantFireRate;
    public GameObject PlantBullet;
    Transform Target;

    Animator ani;

    public float timer=0;
    public float delayBullet=0.7f;
    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        ani=GetComponent<Animator>();
    }
    private void Update()
    {
        float Distance = Vector2.Distance(Target.position, ani.transform.position);
        if (Distance < 10f)
        {
            if (timer <= 0)
            {
                ani.SetBool("isAttack", true);
                Instantiate(PlantBullet, PlantFireRate.position, Quaternion.identity);
                timer = delayBullet;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }
        else if (Distance > 10)
        {
            ani.SetBool("isAttack", false);
        }
    }
}
