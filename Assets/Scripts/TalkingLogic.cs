using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkingLogic : MonoBehaviour
{
    //This script will be attached to the chatbox canvas prefab
    //These public variables will be initialized in the prefabs inspector
    public Texture[] enterImages;
    public Button[] responseButtons;
    public GameObject buttonsEmpty;
    public TextMeshProUGUI text;
    public GameObject enterImageObj;
    //These private variables will be initialized in start when canvas is instantiated
    private GlobalVariables GV;
    private bool done;
    private bool gtg;
    private TextAsset textScript;
    private int lineNumber;
    private bool skipSignal;
    private string[] lines;
    private string[] response;
    private int[] optionsTF;
    private bool enterAnimation;
    private bool holdForResponse;
    private string finalResponse;
    private bool clearButtons;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        //textScript
        lineNumber = 0;
        skipSignal = false;
        gtg = false;
        lines = new string[4];
        response = new string[4];
        optionsTF = new int[4];
        enterAnimation = false;
        holdForResponse = false;
        finalResponse = "";
        clearButtons = false;
        GV = Camera.main.GetComponent<GlobalVariables>();
        buttonsEmpty.SetActive(false);
        textScript = GV.getScript();
        lines = textScript.text.Split('\n');
        startTalking();
        StartCoroutine(enterAnimationF());

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(!holdForResponse)
            {
                if(clearButtons)
                {
                    buttonColorReset();
                    buttonsEmpty.SetActive(false);
                    clearButtons = false;
                }
                if(!done)
                {
                    if(enterAnimation)
                    {
                        enterAnimation = false;
                        startTalking();
                    }else{
                        skipSignal = true;
                    }
                }else{
                    GV.clearScript();
                    GV.swapTalking();
                }
            }
        }
    }
    //Runs the blinking enter button
    private IEnumerator enterAnimationF()
    {
        while(true)
        {
            if(enterAnimation)
            {
                //sets enter image to type 1
                enterImageObj.GetComponent<RawImage>().texture = enterImages[0];
                yield return new WaitForSeconds(0.5f);
                //sets enter image to type 2
                enterImageObj.GetComponent<RawImage>().texture = enterImages[1];
                yield return new WaitForSeconds(0.5f);
            }else{
                //sets enter image to transparent
                enterImageObj.GetComponent<RawImage>().texture = enterImages[2];
            }
        }
    }
    private void startTalking()
    {
        //check to see if next line is 1101588
        //if so, then bool gtg is true and will get the buttons ready
        int result = 0;
        bool canConvert = Int32.TryParse(lines[lineNumber + 1], out result);
        if(canConvert)
        {
            if(result == 1101588)
            {
                gtg = true;
            }
        }
        StartCoroutine(AppendCharacters(lines[lineNumber]));
        skipSignal = false;
        //if good to go for question buttons to appear
        if(gtg)
        {
            holdForResponse = false;
            responseSetup();
        }else{
            enterAnimation = true;
        }
        lineNumber++;
    }
    private IEnumerator AppendCharacters(string line)
    {
        text.text = "";
        foreach(char character in line)
        {
            //if the user hasn't pressed enter while text is appearing then
            //it will progressivly print characters char by char.
            if(!skipSignal)
            {
                text.text += character;
                yield return new WaitForSeconds(0.05f);
            }else{
                text.text = line;
                yield return null;
            }
        }
        yield return null;
    }
    //Begins setting up the buttons
    private void responseSetup()
    {
        //Make them appear
        buttonsEmpty.SetActive(true);
        //Add functions when they're pressed.
        responseButtons[0].onClick.AddListener(Response1OnClick);
        responseButtons[1].onClick.AddListener(Response2OnClick);
        responseButtons[2].onClick.AddListener(Response3OnClick);
        responseButtons[3].onClick.AddListener(Response4OnClick);
        lineNumber++;
        //call the button splitter function which will set the
        //buttons to have the correct true false statement and
        //the right response will appear when certain button clicked.
        for(int i = 0; i < 4; i++)
        {
            lineNumber++;
            buttonSplitter(lines[lineNumber], i);
        }
        //sets up the responses
        for(int i = 0; i < 4; i++)
        {
            lineNumber++;
            responseSetter(lines[lineNumber], i);
        }
        //if its not the end of the script
        if((lineNumber + 1) < lines.Length)
        {
            int result;
            bool canConvert = Int32.TryParse(lines[lineNumber+1], out result);
            if(canConvert)
            {
                if(result == 8675309)
                {
                    gtg = false;
                    lineNumber++;
                }
            }
        }else{
            done = true;
        }
    }
    private void responseSetter(string rLine, int value)
    {
        response[value] = rLine;
    }
    private void buttonSplitter(string rLine, int button)
    {
        bool firstChar = true;
        foreach(char character in rLine)
        {
            if(firstChar)
            {
                optionsTF[button] = Int32.Parse(new string(character, 1));
                responseButtons[button].GetComponentInChildren<TextMeshProUGUI>().text = "";
                firstChar = false;
            }else{
                responseButtons[button].GetComponentInChildren<TextMeshProUGUI>().text += character;
            }
        }
    }
    private void Response1OnClick()
    {
        giveFinalResponse(0);
    }
    private void Response2OnClick()
    {
        giveFinalResponse(1);
    }
    private void Response3OnClick()
    {
        giveFinalResponse(2);
    }
    private void Response4OnClick()
    {
        giveFinalResponse(3);
    }
    private void giveFinalResponse(int e)
    {
        buttonColorChanger();
        finalResponse = response[e];
        clearButtons = true;
        StartCoroutine(appendResponse());
        skipSignal = false;
        enterAnimation = true;
        holdForResponse = true;
    }
    //make the buttons red if wrong green if right
    private void buttonColorChanger()
    {
        for(int i = 0; i < 4; i++)
        {
            if(optionsTF[i] == 0)
            {
                responseButtons[i].GetComponent<Image>().color = Color.red;
            }else{
                responseButtons[i].GetComponent<Image>().color = Color.green;
            }
        }
    }
    private void buttonColorReset()
    {
        for(int i = 0; i < 4; i++)
        {
            responseButtons[i].GetComponent<Image>().color = Color.white;
        }
    }
    private IEnumerator appendResponse()
    {
        text.text = "";
        foreach(char character in finalResponse)
        {
            if(!skipSignal)
            {
                text.text += character;
                yield return new WaitForSeconds(0.5f);
            }else{
                text.text = finalResponse;
                yield return null;
            }
        }
    }
}
