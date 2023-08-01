using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : info
{
    public GameObject tutoPanel;
    public GameObject dialoguePanel;
    public GameObject actionPanel;

    bool tutoOpen = false;
    bool dialogueOpen = false;

    Animator anim_tuto;
    Animator anim_dialogue;
    Animator anim_actionButton;

    void Start()
    {
        anim_tuto = tutoPanel.GetComponent<Animator>();
        anim_dialogue = dialoguePanel.GetComponent<Animator>();
        anim_actionButton = actionPanel.GetComponent<Animator>();
    }

    void Update()
    {
        // 이하 click event들은 blackout 때 안되도록 조건문 걸기
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject.name);

                
                if (!tutoOpen && hit.transform.gameObject.tag == "tutoFile") // tutorial manual
                {
                    Debug.Log("tuto file clicked");
                    anim_tuto.SetTrigger("fileClicked");
                    tutoOpen = true;
                }

                if (hit.transform.gameObject.tag == "mic")
                {
                    anim_dialogue.SetTrigger("micClicked");
                    anim_actionButton.SetTrigger("trigPull");
                    dialogueOpen = true;
                }

            }
        }
    }

    public void TutoOnClickExit()
    {
        anim_tuto.SetTrigger("exitClicked");
        tutoOpen = false;
    }

    public void DialogueOnClickExit()
    {
        anim_dialogue.SetTrigger("exitClicked");
        anim_actionButton.SetTrigger("trigPush");
        dialogueOpen = false;
    }

}
