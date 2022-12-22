using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public static int life = 3;
    private void Update()
    {
        if (life == 2)
        {
            
            Destroy(hearts[2].gameObject);
        }
        else
        {
            if (life == 1)
            {
                Destroy(hearts[1].gameObject);
            }
            else if (life == 0)
            {
                Destroy(hearts[0].gameObject);
            }
        }
    }
}
