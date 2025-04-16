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
    void Start()
    {
        GV = Camera.main.GetComponent<GlobalVariables>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        GV.setButtonValue(ButtonValue);
        //Debug.Log("" + ButtonValue);
    }
    public void OnPointerExit(PointerEventData evetData)
    {
        GV.setButtonValue(0);        
        //Debug.Log("" + 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
