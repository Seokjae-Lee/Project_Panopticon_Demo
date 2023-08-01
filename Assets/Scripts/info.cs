using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    public int[,] map = new int[4, 8]
    {
        {0,0,0,0,0,0,0,0},
        {1,0,0,0,1,0,1,0},
        {0,1,0,0,0,1,0,1},
        {0,0,1,0,0,0,1,0}
    };

    public enum Status
    {
        none,
        isRotating,
        isLifting,
        isZoomingIn,
        isZoomingOut,
        zoomed
    }

    public int currX = 1;
    public int currY = 0;
    public int nextX = 1;
    public int nextY = 0;
}
