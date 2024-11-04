using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class chatboxHandler : MonoBehaviour
{
    public GlobalVariables GV;
    public Transform player;

    public float xThreshold = 2f;
    public float zThreshold = 2f;
    public Material[] objMat;
    public TextMeshProUGUI testText;
    //0 = not close
    //1 = close
    //2 = mouse hovering
    //private float initialPosX;
    //private float initialPosZ;
    private bool close = false;
    private bool hovering = false;
    private Transform thisObj;
    private Vector3 thisObjPos;
    private Renderer rend;
    private bool goodToClick = false;
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        thisObj = this.GetComponent<Transform>();
        thisObjPos = thisObj.position;
        
    }

    void Update()
    {
        float playerX = player.position.x;
        float playerZ = player.position.z;



        float distanceFromObjX = playerX-thisObjPos.x;
        float distanceFromObjZ = playerZ-thisObjPos.z;
        
        if((-2 < distanceFromObjX && distanceFromObjX < 2) && (-2 < distanceFromObjZ && distanceFromObjZ < 2))
        {
            if(hovering)
            {
                rend.material = objMat[2];
                goodToClick = true;
            }else{
                rend.material = objMat[1];
            }
        }else{
            rend.material = objMat[0];
        }

        

    }
    void OnMouseOver()
    {
        hovering = true;
        if(goodToClick && !GV.isTalking())
        {
            if(Input.GetMouseButtonDown(0))
            {
                GV.swapTalking();
            }
        }
    }
    void OnMouseExit()
    {
        hovering = false;
    }
    
}
