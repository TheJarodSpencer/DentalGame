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
    private bool hfr;
    private bool backup;
    private string finalResponse = "";
    private bool clearButtons = false;
    void startSignal()
    {
        textScript = GV.getScript();
        lines = textScript.text.Split('\n');
        gtg = false;
        
    }
    void Update()
    {

    }
}
