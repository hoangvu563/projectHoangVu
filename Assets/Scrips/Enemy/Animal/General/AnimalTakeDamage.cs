using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalTakeDamage : MonoBehaviour
{
    [SerializeField] float heath, maxHeath = 4f;
    Animator animator;
    [SerializeField] AudioSource birdXplode;
    public Slider BossSlider;
    private void Start()
    {
        //ban dau cho mau bang max
        heath = maxHeath;
        animator = GetComponent<Animator>();
        BossSlider.maxValue=maxHeath;
        BossSlider.value = maxHeath;
    }
    public void Takedamage(float dameAmount)
    {
        //moi lan lay damage bang gia tri dameAmount
        //sat thuong gay len ke thu 1 lan bang Damage
        heath-=dameAmount;
        BossSlider.value = heath;
        if (heath <= 0)
        {
            //kich hoat animator ham trigger
            //  animator.SetTrigger("active");
            // birdXplode.Play();  
            Destroy(gameObject);
        }
    }
    //dung trong su kien animator khi con chim no
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
