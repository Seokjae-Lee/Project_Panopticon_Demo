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
            // �ش��ϴ� char thinkpanel�� scale �����ϴ� ���� ������� panel ����
            // �˼��� prefab�� �ش� c# script �ֱ�
        }
    }
}
