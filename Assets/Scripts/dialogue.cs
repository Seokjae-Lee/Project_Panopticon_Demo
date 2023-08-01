using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct DialogueData
{
    public string name;
    public string[] scripts; 
}

public class dialogue : MonoBehaviour
{
    [SerializeField] string eventName;
    [SerializeField] DialogueData[] ddArr;

    public DialogueData[] getDialogue()
    {
        return dialogueProgress.getDialogue(eventName);
    }
}
