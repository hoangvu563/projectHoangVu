using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakeDamage : MonoBehaviour
{
    public float maxHeath=2;
    public float heath;
    //public Slider SliderOfPlay;
    private void Start()
    {
        heath = maxHeath;
       // SliderOfPlay.maxValue = maxHeath;
       // SliderOfPlay.value= maxHeath;   
    }
    public void takeDamageOfPlayer(float Damage)
    {
        heath-=Damage;
       // SliderOfPlay.value = heath;
        if(heath <= 0)
        {
            PlayerHeartSystem.life--;
            //neu chet 1 mang
            if (PlayerHeartSystem.life > 0)
            {
                AudioManager.instance.Play("PlayerDIe");
                transform.position = PlayerMove.LastCheckPoint;
            }
            // neu chet 3 mang
            else if (PlayerHeartSystem.life <= 0)
            {
                PlayerManager.isGameover = true;

            }
        }
    }
}
