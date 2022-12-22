using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatBirdController : MonoBehaviour
{
    //return int
    private enum moveState { idle, ground, hit, fall }

    Rigidbody2D rb;
    Animator ani;

    public Transform groundCheck;
    bool isGround;
    public LayerMask LayerMask1;
    public float distanceLaze = 5;

    Transform target;

    bool isChase;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        ani = transform.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        isGround = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.5f, 0.23f), 0, LayerMask1);
        isChase = Physics2D.Raycast(groundCheck.position, Vector2.down, distanceLaze);
        UpdateAnimator();
    }
    void UpdateAnimator()
    {
        moveState state = new moveState();
        if (isChase)
        {
            rb.gravityScale = 5;
            state = moveState.fall;
        }
        if (isGround)
        {
            state=moveState.ground;
           Invoke("destroy", 2f);
        }
        ani.SetInteger("State", (int)state);
    }
    public void destroy()
    {
        var component = gameObject.GetComponent<AnimalKiller>();
        component.killler();
        component.OnDestroy();
    }
}


