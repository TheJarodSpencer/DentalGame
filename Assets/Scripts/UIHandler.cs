using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject textCanvas;
    public GameObject chatBoxUI;
    public GlobalVariables GV;
    private GameObject uiCanvas;
    private bool canvasExists = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GV.isTalking())
        {
            //chatBoxUI.SetActive(true);
            if(!canvasExists)
            {
                uiCanvas = Instantiate(textCanvas);
                canvasExists = true;
            }
        }else{
            //chatBoxUI.SetActive(false);
            if(canvasExists)
            {
                DestroyImmediate(uiCanvas, true);
                canvasExists = false;
            }
        }
    }
}
