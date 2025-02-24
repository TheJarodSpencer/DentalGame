using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TalkingLogic : MonoBehaviour
{
    public GlobalVariables GV;
    public Texture[] enterImages;
    public Button[] responseButtons;
    public GameObject buttonsEmpty;
    public TextMeshProUGUI text;
    public GameObject enterImageObj;
    private  bool done = false;
    private TextAsset textScript;
    private int lineNumber = 0;
    private bool skipSignal = false;
    private bool gtg = false;
    private string[] lines = new string[4];
    private string[] response = new string[4];
    private int[] optionsTF = new int[4];
    private bool enterAnimation = false;
    private bool holdForResponse = false;
    //private bool hfr;
    private bool backup;
    private string finalResponse = "";
    private bool clearButtons = false;
    void startSignal()
    {
        textScript = GV.getScript();
        lines = textScript.text.Split('\n');
        gtg = false;
        skipSignal = false;
        startTalking();
    }
    private void resetStuff()
    {
        response = new string[4];
        optionsTF = new int[4];
    }
    private void startTalking()
    {
        //This can be removed or reworked depending on how we want to do this
        if(!GV.getAlreadyTalkedTo())
        {
            int result;
            bool canConvert = Int32.TryParse(lines[lineNumber+1], out result);
            if(canConvert)
            {
                if(result == 1101588)
                {
                    gtg = true;
                }
            }
            displayText(lines[lineNumber]);
            if(gtg)
            {
                holdForResponse = true;
                responseSetup();
            }
        }
    }
    private void responseSetup()
    {
        setButtonsActive();
        lineNumber++;
        for(int i = 0; i < 4; i++)
        {
            lineNumber++;
            buttonSplitter(lines[lineNumber], i);
        }
        for(int i = 0; i < 4; i++)
        {
            lineNumber++;
            responseSetter(lines[lineNumber], i);
        }
        if((lineNumber + 1) < lines.Length)
        {
            int result;
            bool canConvert = Int32.TryParse(lines[lineNumber + 1], out result);
            if(canConvert)
            {
                if(result == 8675309)
                {
                    gtg = false;
                    lineNumber++;
                }
            }else{
                done = true;
            }
        }
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
    private void responseSetter(string rLine, int value)
    {
        response[value] = rLine;
    }
    private void setButtonsInactive()
    {
        responseButtons[0].onClick.RemoveAllListeners();
        responseButtons[1].onClick.RemoveAllListeners();
        responseButtons[2].onClick.RemoveAllListeners();
        responseButtons[3].onClick.RemoveAllListeners();
        buttonsEmpty.SetActive(true);
    }
    private void setButtonsActive()
    {
        buttonsEmpty.SetActive(true);
        responseButtons[0].onClick.AddListener(Response1OnClick);
        responseButtons[1].onClick.AddListener(Response2OnClick);
        responseButtons[2].onClick.AddListener(Response3OnClick);
        responseButtons[4].onClick.AddListener(Response4OnClick);
    }
    private void displayText(string line)
    {
        text.text = "";
        foreach(char character in line)
        {
            //look into invoke if this does not work
            text.text += character;
            if(!skipSignal)
            {
                StartCoroutine(waitASec());
            }else{
                text.text = line;
                return;
            }
        }
        if(clearButtons)
        {
            setButtonsInactive();
            resetStuff();
        }
    }
    private IEnumerator waitASec()
    {
        yield return new WaitForSeconds(0.05f);
    }
    void Update()
    {

    }
    void Response1OnClick()
    {

    }
    void Response2OnClick()
    {

    }
    void Response3OnClick()
    {

    }
    void Response4OnClick()
    {

    }
    void collectiveButtonsFunction(int buttonValue)
    {
        buttonColorChanger();
        finalResponse = response[buttonValue];
        displayText(finalResponse);
        clearButtons = true;
    }
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
        backup = true;
    }
    private void buttonColorReset()
    {
        for(int i = 0; i < 4; i++)
        {
            responseButtons[i].GetComponent<Image>().color = Color.white;
        }
    }
    
}
