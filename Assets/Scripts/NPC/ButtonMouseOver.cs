using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GlobalVariables GV;
    public bool isMouseOver = false;
    public int ButtonValue = 0;
    //Just for ensureing when the user goes to select an answer this checker makes sure they are hovering over the button first otherwise they could press enter and select the button by accident
    void Start()
    {
        GV = Camera.main.GetComponent<GlobalVariables>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        GV.setButtonValue(ButtonValue);
    }
    public void OnPointerExit(PointerEventData evetData)
    {
        GV.setButtonValue(0);        
     
    }
   
}
