using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class animationHandler : MonoBehaviour
{
    //element 0 is default frame
    //element 1 is one foot up frame
    //element 2 is second foot up frame
    private Material[] clothesLeft = new Material[4];
    private Material[] clothesRight = new Material[4];
    //0 and 1 are left and left blink 2 and 3 are right and right blink
    private Material[] skin = new Material[4];
    //element 0 is left, element 1 is right
    private Material[] hair;
    private Material[] labcoat;
    private Material[] glasses;
    public GlobalVariables GV;
    public GlobalCharacterMaterials GCM;
    private Renderer clothesRend;
    private Renderer skinRend;
    private Renderer hairRend;
    private Renderer labcoatRend;
    private Renderer glassesRend;
    private bool isWalkingLeft = false;
    private bool isWalkingRight = false;
    private bool isFacingLeft = true;
    private bool isFacingRight = false;
    private bool setTheMaterials = false;
    private bool doneMatSet = false;

    
    //void Start()
    private void setMatObjects()
    {
        
        Transform cobj = transform.Find("clothes");
        if(cobj != null)
        {
            clothesRend = cobj.GetComponent<Renderer>();
        }
        Transform sobj = transform.Find("skin");
        if(sobj != null)
        {
            skinRend = sobj.GetComponent<Renderer>();
        }
        Transform hobj = transform.Find("hair");
        if(hobj != null)
        {
            hairRend = hobj.GetComponent<Renderer>();
        }
        Transform lObj = transform.Find("labcoat");
        if(lObj != null)
        {
            labcoatRend = lObj.GetComponent<Renderer>();
        }
        Transform gObj = transform.Find("glasses");
        if(gObj != null)
        {
            glassesRend = gObj.GetComponent<Renderer>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //if alarm from gcm is ready, and set the materials is false setTheMaterials is true and call set materials
        if(GV.getMatAlarm() && !setTheMaterials)
        {
            setTheMaterials = true; 
        }
        if(setTheMaterials && !doneMatSet)
        {
            setMaterials();
            setMatObjects();
            StartCoroutine(blinkingLoop());
            doneMatSet = true;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            //moving left
            if(!GV.isTalking() && !GV.isPaused())
            {
                isFacingLeft = true;
                isFacingRight = false;
                isWalkingLeft = true;
                hairRend.material = hair[0];
                skinRend.material = skin[0];
                glassesRend.material = glasses[0];
                labcoatRend.material = glasses[0];
                StartCoroutine(walkingLeftAnimation());
                
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            //moving right
            if(!GV.isTalking() && !GV.isPaused())
            {
                isFacingRight = true;
                isFacingLeft = false;
                isWalkingRight = true;
                hairRend.material = hair[1];
                skinRend.material = skin[2];
                glassesRend.material = glasses[1];
                labcoatRend.material = labcoat[1];
                StartCoroutine(walkingRightAnimation());
            }
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            clothesRend.material = clothesLeft[1];
            isWalkingLeft = false;
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            clothesRend.material = clothesRight[1];
            isWalkingRight = false;
        }
    }
    private void setMaterials()
    {
        //Kinda messed up the conversion here so had to manually set the elements. 
        Material[] skinSetter = GCM.getSkin();
        Material[] skinBlinkSetter = GCM.getSkinBlink();
        skin[0] = skinSetter[0];
        skin[1] = skinBlinkSetter[0];
        skin[2] = skinSetter[1];
        skin[3] = skinBlinkSetter[1];
        glasses = GCM.getGlasses();
        labcoat = GCM.getLabcoat();
        hair = GCM.getHairColor();
        Material[] clothesSetter = GCM.getScrubColor();
        clothesLeft[0] = clothesSetter[1];
        clothesLeft[1] = clothesSetter[0];
        clothesLeft[2] = clothesSetter[2];
        clothesLeft[3] = clothesSetter[0];
        clothesRight[0] = clothesSetter[4];
        clothesRight[1] = clothesSetter[3];
        clothesRight[2] = clothesSetter[5];
        clothesRight[3] = clothesSetter[3];
    }
    private IEnumerator blinkingLoop()
    {
        while(true)
        {
            int randSeconds = Random.Range(3, 6);
            yield return new WaitForSeconds(randSeconds);
            blink();
            yield return new WaitForSeconds(0.10f);
            unblink();
        }
    }
    private void blink()
    {
        if(isFacingLeft)
        {
            skinRend.material = skin[1];
        }else if(isFacingRight){
            skinRend.material = skin[3];
        }
    }
    private void unblink()
    {
        if(isFacingLeft)
        {
            skinRend.material = skin[0];
        }else if(isFacingRight){
            skinRend.material = skin[2];
        }
    }
    private IEnumerator walkingLeftAnimation()
    {
        int matIndex = 0;
        while(isWalkingLeft)
        {
            clothesRend.material = clothesLeft[matIndex];
            matIndex++;
            if(matIndex > 3)
            {
                matIndex = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator walkingRightAnimation()
    {    
        int matIndex = 0;
        while(isWalkingRight)
        {
            clothesRend.material = clothesRight[matIndex];
            matIndex++;
            if(matIndex > 3)
            {
                matIndex = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
