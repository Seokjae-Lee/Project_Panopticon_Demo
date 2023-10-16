using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : info
{
    public GameObject mainCam;
    public float rotSpeed; // 45
    public float verSpeed;
    public float zoomSpeed;
    public float zoomDuration;
    public float duration; // 1
    public float cellHeight; // 8.5
    public float zoomRate; // 1
    public GameObject blackoutPanel;

    Animator anim_blackout;

    bool isRotating = false;
    bool isLifting = false;
    bool isZoomingIn = false;
    bool isZoomingOut = false;
    bool zoomIn = false;

    float time;
    float prevAngle;
    Vector3 prevPos;

    int hordir;
    int verdir;



    public Status currStat = Status.none;

    void Start()
    {
        anim_blackout = blackoutPanel.GetComponent<Animator>();
    }

    void Update()
    {
        // 나중에 조건문 정리하기
        if (Input.GetKey(KeyCode.E) && map[currX, currY] == 1 && !isRotating && !isLifting && !isZoomingIn && !isZoomingOut)
        {
            Debug.Log("E PRESSED");

            anim_blackout.SetTrigger("trig");

            if (zoomIn) isZoomingOut = true;
            else isZoomingIn = true;

            prevPos = mainCam.transform.position;
            time = zoomDuration;
            
        }

        if (isZoomingIn)
        {
            time -= Time.deltaTime;
            if (time > 0.0f)
            {
                Vector3 movement = new Vector3(0, 0, 1) * zoomSpeed * Time.deltaTime;
                mainCam.transform.Translate(movement);
            }
            else
            {
                isZoomingIn = false;
                mainCam.transform.position = prevPos + mainCam.transform.localRotation * Vector3.forward * zoomRate;
                zoomIn = true;
            }
        }
        else if (isZoomingOut)
        {
            time -= Time.deltaTime;
            if (time > 0.0f)
            {
                Vector3 movement = new Vector3(0, 0, 1) * zoomSpeed * Time.deltaTime;
                mainCam.transform.Translate(-movement);
            }
            else
            {
                isZoomingOut = false;
                mainCam.transform.position = prevPos - mainCam.transform.localRotation * Vector3.forward * zoomRate;
                zoomIn = false;
            }
        }
        else if (!zoomIn)
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
                    mainCam.transform.eulerAngles = new Vector3(0, prevAngle + 45 * hordir, 0);
                }
            }
            else
            {
                hordir = (int)Input.GetAxisRaw("Horizontal");
                nextY = currY + hordir;
                nextY = nextY > 7 ? 0 : nextY;
                nextY = nextY < 0 ? 7 : nextY;

                prevAngle = mainCam.transform.rotation.eulerAngles.y;
                if (hordir != 0)
                {
                    isRotating = true;
                    time = duration;
                }


                //수직이동 상태 체양
                verdir = (int)Input.GetAxisRaw("Vertical");
                nextX = currX + verdir;
                if (nextX > 3)
                {
                    nextX = 3;
                    verdir = 0;
                }
                else if (nextX < 0)
                {
                    nextX = 0;
                    verdir = 0;
                }

                prevPos = mainCam.transform.position;
                if (verdir != 0)
                {
                    isLifting = true;
                    time = duration;
                }

                currX = nextX;
                currY = nextY;
            }
        }
    }
}
