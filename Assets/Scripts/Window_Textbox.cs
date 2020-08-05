using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_Textbox : MonoBehaviour
{
    private string textString;
    private Text textComponent;
    private Image background;
    private Image ContinueButton;
    private Image Face;
    private GameObject NameTag;
    private Text NameTagText;


    // Start is called before the first frame update
    void Start()
    {
        //textString = new string[50];
        textComponent = GetComponentInChildren<Text>();
        //background = GetComponentInChildren<Image>();
        Image[] images = GetComponentsInChildren<Image>();
        background = images[0];
        ContinueButton = images[1];
        Face = images[2];
        NameTag = images[3].gameObject;
        NameTagText = NameTag.GetComponentInChildren<Text>();

        if (textComponent == null || background == null)
        {
            Debug.LogError("One Component Not Found");
        }
        textComponent.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        ContinueButton.gameObject.SetActive(false);
        Face.gameObject.SetActive(false);
        NameTag.SetActive(false);
    }

    private IEnumerator ShowLetters()
    {
        int numLetters = 0;
        int textLength = textString.Length;
        while (textComponent.text != textString)
        {
            yield return new WaitForSeconds(0.05f);
            textComponent.text += textString[numLetters];
            numLetters++;

        }
        ContinueButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (textString != null)// && Input.GetKeyDown(KeyCode.Space))
        {
            if (textString == textComponent.text && Input.GetKeyDown(KeyCode.Space))
            {
                textString = null;
                if (Textbox_Controller.textSize == 0)
                {
                    textComponent.gameObject.SetActive(false);
                    background.gameObject.SetActive(false);
                    
                }
                ContinueButton.gameObject.SetActive(false);
                NameTag.SetActive(false);
                Face.gameObject.SetActive(false);

            }
            
        }
        else if (Textbox_Controller.text[0] != null)
        {
            textString = Textbox_Controller.text[0];

            //Textbox_Controller.text[0] = null;

            for (int Count = 0;Count<Textbox_Controller.textSize - 1;Count++)
            {
                Textbox_Controller.text[Count] = Textbox_Controller.text[Count + 1];
            }
            Textbox_Controller.text[Textbox_Controller.textSize -1] = null;
            Textbox_Controller.textSize--;
            //textComponent.text = textString;

            string[] newString = textString.Split('\t');
            string nameTag;
            string FaceIcon;
            nameTag = (newString.Length == 3 && newString[0][0] != '0') ? newString[0] : null;
            FaceIcon = (newString.Length == 3 && newString[1][0] != '0') ? newString[1] : null;

            textString = newString[newString.Length - 1];
            textComponent.text = "";
            StartCoroutine(ShowLetters());
            textComponent.gameObject.SetActive(true);
            background.gameObject.SetActive(true);
            if (nameTag != null)
            {
                NameTagText.text = nameTag;
                NameTag.SetActive(true);
            }

            if (FaceIcon != null)
            {
                
                Face.sprite = Resources.Load<Sprite>("Sprites/Faces/" + FaceIcon.Trim());
                if (Face.sprite == null)
                {
                    Debug.LogError("Not found" + FaceIcon);
                }
                Face.gameObject.SetActive(true);
            }

        }
    }
}
