using System;
using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using FullSerializer.Internal.DirectConverters;


//using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class TalkingHandler : MonoBehaviour
{
    //public variables here
    public GlobalVariables GV;
    public Texture[] enterImages;
    public Button[] responseButtons;
    public GameObject buttonsEmpty;
    public TextMeshProUGUI text;
    public GameObject enterImageObj;
    //private ints here
    private bool done = false;
    private TextAsset textScript;
    private int lineNumber = 0;
    private bool skipSignal = false;
    private bool nextSignal = false;
    private bool gtg = false;
    private string[] lines = new string[4];
    private string[] response = new string[4];
    private int[] optionsTF = new int[4];
    private bool enterAnimation = false;
    private bool holdForResponse = false;
    private string finalResponse = "";
    private bool clearButtons = false;
    void Start()
    {
        GV = Camera.main.GetComponent<GlobalVariables>();
        skipSignal = false;
        done = false;
        textScript = GV.getScript();
        lineNumber = 0;
        skipSignal = false;
        nextSignal = false;
        gtg = false;
        lines = new string[4];
        response = new string[4];
        optionsTF = new int[4];
        enterAnimation = false;
        holdForResponse = false;
        finalResponse = "";
        buttonsEmpty.SetActive(false);
        lines = textScript.text.Split('\n');
        startTalking();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(clearButtons)
            {
                buttonColorReset();
                buttonsEmpty.SetActive(false);
                clearButtons = false;
            }
            if(!done)
            {
                if(!holdForResponse)
                {
                    if(enterAnimation)
                    {
                        enterAnimation = false;
                        startTalking();
                    }else{
                        skipSignal = true;
                    }
                }
            }else{
                GV.clearScript();
                GV.swapTalking();
            }
        }
    }
    private IEnumerator enterAnimationF()
    {
        while(enterAnimation)
        {
            enterImageObj.GetComponent<RawImage>().texture = enterImages[0];
            yield return new WaitForSeconds(0.5f);
            enterImageObj.GetComponent<RawImage>().texture = enterImages[1];
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void startTalking()
    {
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
            StartCoroutine(AppendCharacters(lines[lineNumber]));
            lineNumber++;
        }else{
            done = true;
            StartCoroutine(AppendCharacters("Sorry, I'm afraid you have already talked with me."));
        }
    }
    private IEnumerator AppendCharacters(string line)
    {
        text.text = "";
        foreach(char character in line)
        {
            if(!skipSignal)
            {
                text.text += character;
            }else{
                text.text = line;
                yield return null;
            }
        }
        skipSignal = false;
        enterAnimation = true;
        if(gtg)
        {
            holdForResponse = true;
            responseSetup();
        }else{
            StartCoroutine(enterAnimationF());
        }
    }
    private void responseSetup()
    {
        buttonsEmpty.SetActive(true);
        responseButtons[0].onClick.AddListener(Response1OnClick);
        responseButtons[1].onClick.AddListener(Response2OnClick);
        responseButtons[2].onClick.AddListener(Response3OnClick);
        responseButtons[3].onClick.AddListener(Response4OnClick);
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
        lineNumber++;
        if(lineNumber < lines.Length)
        {
            int result;
            bool canConvert = Int32.TryParse(lines[lineNumber], out result);
            if(canConvert)
            {
                if(result == 8675309)
                {
                    gtg = false;
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
        buttonColorChanger();
        finalResponse = response[0];
        StartCoroutine(appendResponse());
        holdForResponse = false;
        clearButtons = true;
    }
    private void Response2OnClick()
    {
        buttonColorChanger();
        finalResponse = response[1];
        StartCoroutine(appendResponse());
        holdForResponse = false;
        clearButtons = true;
    }
    private void Response3OnClick()
    {
        buttonColorChanger();
        finalResponse = response[2];
        StartCoroutine(appendResponse());
        holdForResponse = false;
        clearButtons = true;
    }
    private void Response4OnClick()
    {
        buttonColorChanger();
        finalResponse = response[3];
        StartCoroutine(appendResponse());
        holdForResponse = false;
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
            }else{
                text.text = finalResponse;
                yield return null;
            }
        }
        skipSignal = false;
        enterAnimation = true;
        //done = true;
    }
}
