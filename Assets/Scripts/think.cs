using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class think : info
{
    void OnMouseDown()
    {
        if (map[currX, currY] == 1)
        {
            Debug.Log("this is " + currX + " " + currY);
            // 해당하는 char thinkpanel의 scale 조절하는 등의 방식으로 panel 띄우기
            // 죄수방 prefab에 해당 c# script 넣기
        }
    }
}
