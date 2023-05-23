using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject mainCam;
    public float rotSpeed; // 45
    public float verSpeed;
    public float duration; // 1
    public float cellHeight; // 5.1


    bool isRotating = false;
    bool isLifting = false;

    float time;
    float prevAngle;
    Vector3 prevPos;

    int hordir;
    int verdir;

    void Start()
    {
        
    }

    void Update()
    {
        // 나중가서 조건 추가
        if (true)
        {
            if (isLifting)
            {
                time -= Time.deltaTime;
                if (time > 0.0f)
                {
                    Vector3 movement = new Vector3(0f, verdir, 0f) * verSpeed * Time.deltaTime;
                    mainCam.transform.Translate(movement);
                }
                else
                {
                    isLifting = false;
                    mainCam.transform.position = prevPos + new Vector3(0, verdir * cellHeight, 0);
                }
            }
            else if (isRotating)
            {
                time -= Time.deltaTime;
                if (time > 0.0f)
                {
                    mainCam.transform.Rotate(Vector3.up * Time.deltaTime * hordir * rotSpeed);
                }
                else
                {
                    isRotating = false;
                    // mainCam.transform.rotation = Quaternion.Euler(0, prevY + 45 * dir, 0);
                    mainCam.transform.eulerAngles =  new Vector3(0, prevAngle + 45 * hordir, 0);
                }
            }
            else
            {
                hordir = (int) Input.GetAxisRaw("Horizontal");
                prevAngle = mainCam.transform.rotation.eulerAngles.y;
                if (hordir != 0)
                {
                    isRotating = true;
                    time = duration;
                }


                //수직이동 상태 체양
                verdir = (int)Input.GetAxisRaw("Vertical");
                prevPos = mainCam.transform.position;
                if (verdir != 0)
                {
                    isLifting = true;
                    time = duration;
                }

            }
        }
    }
}
