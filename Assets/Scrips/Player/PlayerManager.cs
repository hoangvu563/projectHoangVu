using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameover;
    public GameObject gameOverScreen;

    public static bool isGameFinish;
    public GameObject gameFinishScreen;

    public GameObject gamePause;

    private void Start()
    {
        isGameover = false;
        isGameFinish = false;

    }
    private void Update()
    {
        if (isGameover==true)
        {
            gameOverScreen.SetActive(true);
            gameObject.SetActive(false);
        }
        if(isGameFinish == true)
        {
            gameFinishScreen.SetActive(true);
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePause.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void Resetbutton()
    {
        gamePause.SetActive(false);
        gameFinishScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameObject.SetActive(true);
    }
}
