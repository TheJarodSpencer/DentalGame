using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TalkingHandler : MonoBehaviour
{
    public Texture[] enterImages;
    public GameObject enterImageObj;
    public TextAsset textFile;
    public TextMeshProUGUI text;
    public GlobalVariables GV;
    public string[] lines;
    private bool nextTextSignal = false;
    private bool initialTextSignal = false;
    private int lineNumber = 0;
    private bool enterAnimation = false;
    void Start()
    {
        enterAnimation = false;
        initialTextSignal = false;
        nextTextSignal = false;
        lineNumber = 0;
        text.text = "";
        if(textFile != null)
        {
            lines = textFile.text.Split('\n');
        }
        enterImageObj.GetComponent<RawImage>().texture = enterImages[2];
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GV.isTalking())
        {
            if(!initialTextSignal)
            {
                nextTextSignal = true;
                initialTextSignal = true;
            }
            if(nextTextSignal)
            {
                if(lineNumber < lines.Length)
                {
                    enterAnimation = false;
                    startTalking();
                    nextTextSignal = false;
                }else{
                    GV.swapTalking();
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Return) && enterAnimation)
        {
            nextTextSignal = true;
        }
        if(!enterAnimation)
        {
            enterImageObj.GetComponent<RawImage>().texture = enterImages[2];
        }
    }
    private void startTalking()
    {
        text.text = "";
        StartCoroutine(AppendCharacters(lines[lineNumber]));
        lineNumber++;
    }
    private IEnumerator AppendCharacters(string line)
    {
        foreach(char character in line)
        {
            text.text += character;
            yield return new WaitForSeconds(0.05f);
        }
        enterAnimation = true;
        StartCoroutine(EnterAnimation());
    }
    private IEnumerator EnterAnimation()
    {
        while(enterAnimation)
        {
            enterImageObj.GetComponent<RawImage>().texture = enterImages[0];
            yield return new WaitForSeconds(0.5f);
            enterImageObj.GetComponent<RawImage>().texture = enterImages[1];
            yield return new WaitForSeconds(0.5f);
        }
    }

}
