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

    public LevelButtonManager LBM;

    public GameObject FadePrefab;

    private GameObject temp;
    void Start()
    {
        temp = Instantiate(FadePrefab);
        Invoke("Kill", 0.5f);
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
                //LBM.diagnosisButton.SetActive(false);

            }
        }else{
            //chatBoxUI.SetActive(false);
            if(canvasExists)
            {
                DestroyImmediate(uiCanvas, true);
                canvasExists = false;
                GV.setTalkingSound(false);
            }
        }
    }

    void Kill() {
        Destroy(temp);
    }
}
