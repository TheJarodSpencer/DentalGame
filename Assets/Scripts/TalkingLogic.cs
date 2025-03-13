using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.UI;

public class TalkingLogic : MonoBehaviour
{
    public TalkingHandler TH;
    public GlobalVariables GV;
    //public Texture[] enterImages;
    public Button[] responseButtons;
    public GameObject buttonsEmpty;
    public TextMeshProUGUI text;
    //public GameObject enterImageObj;
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
    public void startSignal()
    {
        textScript = GV.getScript();
        lines = textScript.text.Split('\n');
        gtg = false;
        skipSignal = false;
        lines = textScript.text.Split('\n');
        lineNumber = 0;
        TH.establishScriptSize(lines.Length);
        startTalking();
    }
    public void startTalking()
    {
        if(clearButtons)
        {
            restoreButtonColors();
            buttonsEmpty.SetActive(false);
            lineNumber = lineNumber + 10;
            clearButtons = false;
        }
        int result;
        if(Int32.TryParse(lines[lineNumber+1], out result))
        {
            if(result == 1101588)
            {
                gtg = true;
            }
        }

        TH.talk(lines[lineNumber], lineNumber);

        if(gtg)
        {
            addButtonListeners();
            buttonSetup(lineNumber+2, 0);
            buttonSetup(lineNumber+3, 1);
            buttonSetup(lineNumber+4, 2);
            buttonSetup(lineNumber+5, 3);
            responseSetup(lineNumber+6, 0);
            responseSetup(lineNumber+7, 1);
            responseSetup(lineNumber+8, 2);
            responseSetup(lineNumber+9, 3);
            holdForResponse = true;
        }
    }
    private void responseSetup(int ln, int element)
    {
        response[element] = lines[ln];
    }
    private void buttonSetup(int ln, int element)
    {
        
        bool firstChar = true;
        foreach(char character in lines[ln])
        {
            if(firstChar)
            {
                optionsTF[element] = Int32.Parse(new string(character, 1));
                responseButtons[element].GetComponentInChildren<TextMeshProUGUI>().text = ""; 
                firstChar = false;
            }else{
                responseButtons[element].GetComponentInChildren<TextMeshProUGUI>().text += character;
            }
        }
        //response[element] = lines[ln];
    }
    private void addButtonListeners()
    {
        responseButtons[0].onClick.AddListener(onButton1Click);
        responseButtons[1].onClick.AddListener(onButton2Click);
        responseButtons[2].onClick.AddListener(onButton3Click);
        responseButtons[3].onClick.AddListener(onButton4Click);
        
    }
    private void removeButtonListeners()
    {
        responseButtons[0].onClick.RemoveAllListeners();
        responseButtons[2].onClick.RemoveAllListeners();
        responseButtons[3].onClick.RemoveAllListeners();
        responseButtons[4].onClick.RemoveAllListeners();
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(TH.getIsTalking())
            {
                TH.skipSignal(lines[lineNumber], lineNumber);
            }else{
                if(!holdForResponse)
                {
                    lineNumber++;
                    startTalking();
                }
            }
        }
        if(holdForResponse && !TH.getIsTalking())
        {
            buttonsEmpty.SetActive(true);
        }
    }
    public void onButton1Click()
    {
        respond(0);
    }
    public void onButton2Click()
    {
        respond(1);
    }
    public void onButton3Click()
    {
        respond(2);
    }
    public void onButton4Click()
    {
        respond(3);
    }
    public void respond(int buttonValue)
    {
        holdForResponse = false;
        int ln = lineNumber + 6 + buttonValue;
        TH.talk(response[buttonValue], ln);
        changeButtonColors(buttonValue);
        clearButtons = true;
    }
    private void changeButtonColors(int buttonValue)
    {
        for(int i = 0; i < 4; i++)
        {
            if(optionsTF[i] == 0)
            {
                responseButtons[i].GetComponent<Image>().color = Color.red;
                if(i == buttonValue)
                {
                    //Send incorrect to score card
                }
            }else{
                responseButtons[i].GetComponent<Image>().color = Color.green;
                if(i == buttonValue)
                {
                    //Send correct to score card
                }
            }
        }
    }
    private void restoreButtonColors()
    {
        for(int i = 0; i < 4; i++)
        {
            responseButtons[i].GetComponent<Image>().color = Color.grey;
        }
    }


}
