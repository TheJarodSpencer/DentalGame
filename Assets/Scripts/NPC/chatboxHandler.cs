using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class chatboxHandler : MonoBehaviour
{
    public GlobalVariables GV;
    public Transform player;
    public TextAsset talkingScript;
    public float xThreshold = 2f;
    public float zThreshold = 2f;
    public Transform thisCharacter;
    //public Material[] objMat;
    
    //0 = not close
    //1 = close
    //2 = mouse hovering
    //private float initialPosX;
    //private float initialPosZ;
    private GameObject highlighter;
    private bool close = false;
    private bool hovering = false;
    private Transform thisObj;
    private Vector3 thisObjPos;
    private Renderer rend;
    private GameObject hoverDetector;
    private bool goodToClick = false;
    private bool alreadyTalkedTo = false;

    public bool canFLip; //changed in levelButtonManager, prevents alreadyTalkedTo from being set prematurely

    private float talkDistance = 10.0f;
    void Start()
    {
        //rend = this.GetComponent<Renderer>();
        //highlighter = this.GetComponentInChildren<>("highlight");
        Transform findObject = thisCharacter.Find("highlight");
        if(findObject != null)
        {
            highlighter = findObject.gameObject;
        }
        findObject = thisCharacter.Find("hoverDetector");
        if(findObject != null)
        {
            hoverDetector = findObject.gameObject;
        }
        highlighter.SetActive(false);
        thisObj = this.GetComponent<Transform>();
        thisObjPos = thisObj.position;
    }

    void Update()
    {
        float playerX = player.position.x;
        float playerZ = player.position.z;



        float distanceFromObjX = playerX-thisObjPos.x;
        float distanceFromObjZ = playerZ-thisObjPos.z;
        
        if((MathF.Abs(distanceFromObjX) < talkDistance) && (MathF.Abs(distanceFromObjZ) < talkDistance))
        {
            if(hovering)
            {
                //rend.material = objMat[2];
                highlighter.SetActive(true);
                goodToClick = true;
            }else{
                //rend.material = objMat[1];
                highlighter.SetActive(false);
            }
        }else{
            highlighter.SetActive(false);
        }

        

    }
    
    void OnMouseOver()
    {
        hovering = true;
        if(goodToClick && !GV.isTalking())
        {

            if(Input.GetMouseButtonDown(0))
            {
                
                GV.setAlreadyTalkedTo(alreadyTalkedTo);
                GV.setScript(talkingScript);
                if(canFLip) {
                    alreadyTalkedTo = true;
                }
                GV.swapTalkSignal();
                GV.swapTalking();
                
            }
        }
    }
    void OnMouseExit()
    {
        hovering = false;
    }
    
}
