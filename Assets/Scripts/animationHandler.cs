using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandler : MonoBehaviour
{
    //element 0 is default frame
    //element 1 is one foot up frame
    //element 2 is second foot up frame
    public Material[] clothesLeft;
    public Material[] clothesRight;
    //element 0 is left, element 1 is right
    public Material[] skin;
    public Material[] hair;
    public GlobalVariables GV;
    private Transform clothesObj;
    private Transform skinObj;
    private Transform hairObj;
    
    void Start()
    {
        //clothesObj = transform.GetComponent();
    }

    // Update is called once per frame
    void Update()
    {
        while(Input.GetKeyDown(KeyCode.A))
        {
            //moving left
            if(!GV.isTalking() && !GV.isPaused())
            {
                
            }
        }
        while(Input.GetKeyDown(KeyCode.D))
        {
            //moving right
        }
    }
}
