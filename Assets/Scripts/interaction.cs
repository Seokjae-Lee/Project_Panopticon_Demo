using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class interaction : MonoBehaviour
{
    [SerializeField] Camera cam;

    public TMP_Text nameText;
    public TMP_Text scriptText;
    DialogueData[] dd;

    bool onDialogue = false;
    bool dialogueEnd = false;
    int index = 0;

    public void printDialogue()
    {
        Debug.Log(index);
        if (index == -1)
        {
            // dialogue 창 없애기 anim
            Debug.Log("dialogue end");
            index = 0;
            return;
        }
        Debug.Log("now " + index);
        if (index >= dd.Length)
        {
            onDialogue = false;
            dialogueEnd = true;
            index = -1;
            return;
        }
        nameText.text = dd[index].name;
        string toPrint = "";
        foreach (string script in dd[index].scripts) toPrint += script;
        scriptText.text = toPrint;
        index++;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject.name);

                if (hit.transform.gameObject.tag == "mic")
                {
                    index = 0;
                    dd = hit.transform.GetComponent<dialogue>().getDialogue();
                    onDialogue = true;
                    dialogueEnd = false;
                    printDialogue();
                }

            }
        }
    }
    
}
