using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEvent : MonoBehaviour
{
    Transform player;
    private float value;
    public Slider volumeSlider;
    public AudioMixer mixer;
    //private void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //    //mixer.GetFloat("volume", out value);
    //    //volumeSlider.value = value;
    //}
    
    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        PlayerHeartSystem.life = 3;
        PlayerMove.LastCheckPoint = new Vector2(-13, 1);
    }
}
