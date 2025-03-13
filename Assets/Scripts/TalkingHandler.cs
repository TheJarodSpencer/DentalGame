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
    public TextMeshProUGUI text;
    public bool[] lineFinished;
    public bool isTalking = true;
    public void establishScriptSize(int size)
    {
        lineFinished = new bool[size];
        for(int i = 0; i < size; i++)
        {
            lineFinished[i] = false;
        }
    }
    public void talk(string line, int lineNumber)
    {
        StartCoroutine(appendCharacters(line, lineNumber));
        isTalking = true;
    }
    public void skipSignal(string line, int lineNumber)
    {
        lineFinished[lineNumber] = true;
        StopCoroutine(appendCharacters(line, lineNumber));
        isTalking = false;
        text.text = line;
    }
    private IEnumerator appendCharacters(string line, int lineNumber)
    {
        foreach(char character in line)
        {
            if(!lineFinished[lineNumber])
            {
                text.text += character;
                yield return new WaitForSeconds(0.05f);
            }
        }
        isTalking = false;
        yield return null;

    }
    public bool getIsTalking()
    {
        return isTalking;
    }
}
