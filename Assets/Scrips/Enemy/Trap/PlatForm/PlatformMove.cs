using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    // hai diem platform di toi
    public Transform[] wayPoits;
    public int indexer = 0;
    public float moveSpeed = 2f;
    private void Update()
    {
        if ((Vector2.Distance(wayPoits[indexer].transform.position, this.transform.position)) <= 0.1f)
        {
            indexer++;
            //this.transform.Rotate(0, 180, 0);
            if(indexer >= wayPoits.Length)
            {
                indexer = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoits[indexer].transform.position, moveSpeed * Time.deltaTime);
    }


}
