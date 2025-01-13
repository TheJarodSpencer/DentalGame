using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandler : MonoBehaviour
{
    public Material[] clothesLeft;
    public Material[] clothesRight;
    public Material[] skin;
    public Material[] hair;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(Input.GetKeyDown("A"))
        {
            //moving left
        }
        while(Input.GetKeyDown("D"))
        {
            //moving right
        }
    }
}
