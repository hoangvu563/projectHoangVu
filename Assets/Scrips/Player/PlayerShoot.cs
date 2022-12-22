using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletPosition;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    [SerializeField] AudioSource bulletaudio;
    private void Update()
    {
        //LAY VI TRI CUA CON TRO CHUOT
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //lAY HUONG CUA SUNG
        Vector3 rotation = mousePos - transform.position;
        //Mathf.Atan2: TRA VE 1 góc là radian có tan=y/x
        //Mathf.Rad2Deg:HE SO CHUYEN RADIAN SANG DO
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;//=> KET QUA TRA VE 1 GOC
        //hàm Quaternion.Euler QUAY QUANH 1 TRUC
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (!canFire)
        {
            //neu khong the ban thi thoi gian = cong don 2 khung hinh
            timer += Time.deltaTime;
            //  khoang thoi gian giua 2 lan ban lon hon timeBetweenFiring thi co the ban va reset timer ve 0
            if (timer > timeBetweenFiring)
            {
                canFire=true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            bulletaudio.Play();
            canFire = false;
            //sao chep ra mot vien dan
            Instantiate(bullet, bulletPosition.position, Quaternion.identity);
        }
    }
}
