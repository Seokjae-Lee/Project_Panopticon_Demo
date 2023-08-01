using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueProgress : MonoBehaviour
{
    private static Dictionary<string, DialogueData[]> dialogueDict = new Dictionary<string, DialogueData[]>();

    [SerializeField] private TextAsset file = null;

    public static DialogueData[] getDialogue(string eventName)
    {
        return dialogueDict[eventName];
    }

    string csvText;
    string[] rows;

    public void setDD()
    {
        csvText = file.text.Substring(0, file.text.Length - 1);
        rows = csvText.Split(new char[] { '\n' });

        for (int i = 1; i < rows.Length; i++)
        {
            string[] rowValues = rows[i].Split(new char[] { ',' });

            if (rowValues[0].Trim() == "" || rowValues[0].Trim() == "end") continue;

            string eventName = rowValues[0];
            DialogueData[] dd = getDD(rowValues, ref i);

            dialogueDict.Add(eventName, dd);
        }
    }


    DialogueData[] getDD(string[] rowValues, ref int index)
    {
        List<DialogueData> ddList = new List<DialogueData>();

        while (rowValues[0].Trim() != "end") 
        {
            List<string> scriptList = new List<string>();

            DialogueData dd;
            dd.name = rowValues[1]; 

            do 
            {
                scriptList.Add(rowValues[2].ToString());
                if (++index < rows.Length) rowValues = rows[index].Split(new char[] { ',' });
                else break;
            } while (rowValues[1] == "" && rowValues[0] != "end");

            dd.scripts = scriptList.ToArray();
            ddList.Add(dd);
        }

        return ddList.ToArray();
    }

    private void Awake()
    {
        setDD();
    }

}
