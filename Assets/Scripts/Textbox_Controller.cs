using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class Textbox_Controller : MonoBehaviour
{
    static public Textbox_Controller instance;
    static public string[] text;
    static public int textSize;
    static public TextAsset script;
    static private string[] scriptText;
    //static public string nameTag;
    //static public string portrait;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        text = new string[50];
        script = Resources.Load<TextAsset>("Script/Test_Script");
        //scriptText = script.text.Split("\n"[0]);
        scriptText = script.text.Split(new string[] { "\r\n\r\n" },System.StringSplitOptions.None);
        Debug.Log(scriptText.Length);
        //nameTag = null;
        //portrait = null;
    }
    
    public static void AddNewText(string inputText)
    {
        if (textSize == 50) { return; }
        Debug.Log("New Text added");
        text[textSize] = inputText;

        /*
        string[] newString = inputText.Split('\t');
        text[textSize] = newString[newString.Length - 1];
        if (newString.Length == 3)
        {
            nameTag = (newString[0][0] != '0') ? newString[0] : null;

        }
        else
        {
            nameTag = null;
        }
        */
        textSize++;
        Debug.Log(text);
    }

    public static void AddNewText(string[] input, int Size)
    {

        for (int Count = 0;Count<Size; Count++)
        {
            AddNewText(input[Count]);
        }
    }

    //FOR CLARITY, SCRIPT LINE NUMBERS HERE START AT 1. EG SCRIPT LINE 1 = STRING 0, LINE 2 = STRING 1. DONT CALL SCRIPT LINE 0
    public static void AddTextByLineNumber(int LineNumber)
    {
        if (LineNumber > scriptText.Length || LineNumber <= 0)
        {
            return;
        }

        AddNewText(scriptText[LineNumber - 1]);
    }

    //END INCLUSIVE
    public static void AddTextByLineNumber(int beginning, int end)
    {
        if (beginning > end || beginning <= 0 || end > scriptText.Length || beginning > scriptText.Length || end <= 0)
        {
            return;
        }
        for (int Count = beginning - 1;Count<end;Count++)
        {
            AddTextByLineNumber(Count);
        }

    }
}

