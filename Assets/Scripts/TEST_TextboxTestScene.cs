using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_TextboxTestScene : MonoBehaviour
{
    private string[] Strings;
    private int Counter;

    // Start is called before the first frame update
    void Start()
    {
        Strings = new string[5] { "string 1", "string 2", "string 3", "a string 4", "string 5" };
        //Strings = { "string 1", "string 2", "string 3", "a string 4", "string 5" };

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q hit");
            Textbox_Controller.AddNewText(Strings[Counter]);
            Counter++;
            Counter %= 5;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W hit");
            Textbox_Controller.AddNewText(new string[] { "Group string 1", "group string 2", "group 3" }, 3);
        }


        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E hit");
            Textbox_Controller.AddTextByLineNumber(1);
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R hit");
            Textbox_Controller.AddTextByLineNumber(3);
        }
    }
}
