using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /*Component of Player*/
    private Rigidbody2D rb;
    private Animator anim;

    public static Vector2 LastCheckPoint = new Vector2(-13, 1);
    /* Running system*/
    public float directionX;
    public float moveSpeed;

    /*Ground jump system*/
    public LayerMask jumableground;
    public Transform groundCheck;
    bool isGroundTouch;
    public float hightJump;
    bool doubleJump;

    /*Wall jump and sliding Wall system*/
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSldingSpeed;
    public Vector2 wallJumpForce;
    bool wallJumping;

    /*animator system*/
    private enum MovementState {idle,running,jumping,falling,walljump}
    /*Audio controller*/
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = LastCheckPoint;
    }
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
    }
    private void Update()
    {
        /*Wall Sliding System*/
        this.isWall();
        this.checkSlidingWall();
        this.slidingWall();

        /*Wall Jump System*/
        this.checjJumpWall();
        this.jumpWall();

        /*Ground jump System*/
        this.isGround();
        this.jumpGround();


        /* player sword*/
         sword();

        /*Running Player System*/
        directionX = Input.GetAxisRaw("Horizontal");/*Lay tin hieu tu ban phim*/
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        /* Animator System*/
        updateanimationState();
    }
    private void updateanimationState()
    {
        MovementState state;
        if (directionX > 0)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(0.5f,0.5f ,1 );
        }
        else if (directionX < 0)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            //anim.SetBool("running", true);
        }
        else
        {
            state = MovementState.idle;
            //anim.SetBool("running", false);
        }
        if (isSliding && Input.GetButtonDown("Jump") == false)
        {
            state = MovementState.walljump;
        }
        if (rb.velocity.y > 0)
        {
            state = MovementState.jumping;
        }
        //else if (rb.velocity.y < 0)
        //{
        //    state = MovementState.falling;
        //}
       // kich hoat animator theo so
        anim.SetInteger("State",(int)state);
    }
    private bool isGround()
    {
        //kiem tra xem co ground co cham dat hay khong
        //tra ve true hoac false
        //groundCheck.position; vi tri kiem tra
        // new Vector2(0.5f, 0.23f): kich thuoc cua vi tri kiem tra
        // 0: goc xoay
        // jumableground: layer kiem tra o trong gid
        return isGroundTouch = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.5f, 0.23f), 0, jumableground);
        //return Isground = Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,0.1f, jumableground);
    }
    private void jumpGround()
    {
        if (isGroundTouch)
        {
            doubleJump = true;
        }
        if (Input.GetButtonDown("Jump") && isGroundTouch)
        {
            AudioManager.instance.Play("Jump");
            this.rb.velocity = new Vector2(rb.velocity.x, this.hightJump);
        }
        if (Input.GetButtonDown("Jump") && isGroundTouch == false && doubleJump == true)
        {
            AudioManager.instance.Play("Doublejupm");
            rb.velocity = new Vector2(rb.velocity.x, this.hightJump);
            doubleJump = false;
        }
    }
    // kiem tra xem co cham tuong hay khong
    private bool isWall()
    {
        return isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.33f, 2), 0, jumableground);
    }
    private void checkSlidingWall()
    {
        if (isWallTouch==true && isGroundTouch==false)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }
    }
    private void slidingWall()
    {
        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSldingSpeed, float.MaxValue));
        }
    }
    private void checjJumpWall()
    {
        if (isSliding)
        {
            wallJumping = true;
        }
        else
        {
            wallJumping = false;
        }
    }
    private void jumpWall()
    {
        if (wallJumping && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(-directionX * wallJumpForce.x, wallJumpForce.y);
        }
    }
    void sword()
    {
        if (anim.GetBool("sword"))
        {
            anim.SetBool("sword", false);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetBool("sword", true);
        }
    }
}
