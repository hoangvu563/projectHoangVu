using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Itemcollector : MonoBehaviour
{
    private int banana = 0;

    [SerializeField]private Text bananaText;
    [SerializeField] private Text ScoreOverGameText;
    [SerializeField] private Text ScoreFinishGameText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("a"))
        {
            Destroy(collision.gameObject);
            banana++;
            bananaText.text="Banana: " + banana*100;
            ScoreOverGameText.text = "Score: " + banana*100;
            ScoreFinishGameText.text = "Score: " + banana * 100;
            AudioManager.instance.Play("coin");
        }
    }
}
