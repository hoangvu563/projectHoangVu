using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private AudioSource AudioSource;
    private float valueVolume = 1;
    private void Start()
    {
        AudioSource=GetComponent<AudioSource>();    
    }
    private void Update()
    {
        AudioSource.volume=valueVolume;
    }
    public void setVolume(float vol)
    {
        valueVolume = vol;
    }
}
