using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject chatBoxUI;
    public GlobalVariables GV;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GV.isTalking())
        {
            Debug.Log("true");
            chatBoxUI.SetActive(true);
        }else{
            chatBoxUI.SetActive(false);
        }
    }
}
