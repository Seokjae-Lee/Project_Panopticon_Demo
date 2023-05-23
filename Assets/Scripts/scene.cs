using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public int currScene; 


    void Update()
    {
        int input = (int) Input.GetAxisRaw("Vertical");
        if (input != 0)
        {
            int nextSceneNum = currScene + input;
            if (nextSceneNum > 4 || nextSceneNum <= 0) return;
            string nextScene = (currScene + input).ToString() + "F";
            SceneManager.LoadScene(nextScene);
        }
    }
}
