using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
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
    private TextAsset textScript;
    private bool holdForResponse = false;
    private bool done = false;
    private bool gtg = false;
    private int lineNumber = 0;
    private string[] lines;
    public void initialize()
    {
        holdForResponse = false;
        textScript = GV.getScript();
        lineNumber = 0;
        lines = textScript.text.Split('\n');
        bool regularDialogue = true;
        
        for(int i = 0; i < lines.Length; i++)
        {
            int result;
            bool canConvert = Int32.TryParse(lines[lineNumber], out result);
            if(canConvert)
            {
                if(result == 1101588)
                {
                    regularDialogue = false;
                }else if(result == 8675309){
                    regularDialogue = true;
                }

            }
        }
    }
    void Update()
    {

    }
}
