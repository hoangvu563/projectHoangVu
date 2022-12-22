using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : PlayerHeartSystem
{
    private Animator ani;
    private Rigidbody2D rb;
    Sprite sp;
    public GameObject PlayerExplode;
    private void Start()
    {
        rb=transform.GetComponent<Rigidbody2D>();   
        ani =transform.GetComponent<Animator>();
        sp=gameObject.GetComponent<Sprite>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("staticTraps")|| collision.gameObject.CompareTag("animalTrap"))
        {
            PlayerHeartSystem.life--;

            //neu chet 1 mang
            if (life > 0)
            {
                gameObject.SetActive(false);
                AudioManager.instance.Play("PlayerDIe");
                var a = Instantiate(PlayerExplode, transform.position, Quaternion.identity);
                Invoke("repawn", 1.5f);
                Destroy(a, 2f);
                //sword();

                //transform.position= PlayerMove.LastCheckPoint;
            }
            // neu chet 3 mang
           else if(PlayerHeartSystem.life <= 0)
            {
               PlayerManager.isGameover = true;
                //sword();

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("animalTrap")|| collision.gameObject.CompareTag("PlayerSword"))
        {
            var component = collision.gameObject.GetComponent<AnimalKiller>();
            component.killler();
            component.OnDestroy();
            Debug.Log("hoang");
        }
    }
    // neu restart level hien tai goi ham die.
    public virtual void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        // sau 1s moi chay ham RestartLevel().
        Invoke("RestartLevel",0);
        AudioManager.instance.Play("GameOver");
    }
    public void RestartLevel()
    {
        // player ve begin.position.
        PlayerMove.LastCheckPoint = new Vector2(-13, 1);
        //reset heart =3.
        PlayerHeartSystem.life = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void repawn()
    {
        gameObject.SetActive(true);
        transform.position = PlayerMove.LastCheckPoint;
    }
    //void sword()
    //{
    //    if (ani.GetBool("sword"))
    //    {
    //        ani.SetBool("sword", false);
    //    }
    //}
}
