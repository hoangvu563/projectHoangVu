using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform MainCamera;
    public Transform MiddleBG;
    public Transform SideBG;
    private void Update()
    {
        if(MainCamera.position.x > MiddleBG.position.x)
        {
            SideBG.position = MiddleBG.position + Vector3.right * 48;
        }
        if (MainCamera.position.x < MiddleBG.position.x)
        {
            SideBG.position = MiddleBG.position + Vector3.left * 48;
        }
        if(MainCamera.position.x>SideBG.position.x|| MainCamera.position.x < SideBG.position.x)
        {
            // bai toan doi cho MiddleBG va SideBG
            Transform z = SideBG;
            SideBG = MiddleBG;
            MiddleBG = z;
        }
    }
}
