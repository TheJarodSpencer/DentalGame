using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    //public GameObject regularUI;
    public GameObject chatBoxUI;
    public GlobalVariables GV;
    private bool canvasExists = false;
    public TalkingLogic tl;
    void Start()
    {
        chatBoxUI.SetActive(false);
        canvasExists = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GV.isTalking())
        {
            if(!canvasExists)
            {
                chatBoxUI.SetActive(true);
                //regularUI.SetActive(false);
                canvasExists = true;
            }
        }else{
            if(canvasExists)
            {
                chatBoxUI.SetActive(false);
                //regularUI.SetActive(true);
                canvasExists = false;
            }
        }
    }
}
