using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject mainCam;
    public float rotSpeed; // 45
    public float duration; // 1

    bool isRotating = false;
    float time;
    float prevY;
    int dir;

    void Start()
    {
        
    }

    void Update()
    {
        // 나중가서 조건 추가
        if (true)
        {
            if (isRotating)
            {
                time -= Time.deltaTime;
                if (time > 0.0f)
                {
                    mainCam.transform.Rotate(Vector3.up * Time.deltaTime * dir * rotSpeed);
                }
                else
                {
                    isRotating = false;
                    // mainCam.transform.rotation = Quaternion.Euler(0, prevY + 45 * dir, 0);
                    mainCam.transform.eulerAngles =  new Vector3(0, prevY + 45 * dir, 0);
                }
            }
            else
            {
                dir = (int) Input.GetAxisRaw("Horizontal");
                prevY = mainCam.transform.rotation.eulerAngles.y;
                if (dir != 0)
                {
                    isRotating = true;
                    time = duration;
                }
            }
        }
    }
}
