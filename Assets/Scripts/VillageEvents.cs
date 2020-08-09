using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class VillageEvents : MonoBehaviour
{
    [SerializeField] private int Index;
    private bool canTrigger;

    private void Start()
    {
        canTrigger = false;
    }

    private void Update()
    {
        if (!EventHandler.isBusy && !Textbox_Controller.isClosing && canTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            switch(Index)
            {
                case 1:
                    Textbox_Controller.AddNewText("Test");
                    break;

                default:
                    Textbox_Controller.AddNewText("ERROR");
                    Debug.LogError("This event does not exist: " + Index);
                    break;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTrigger = false;
    }
}
