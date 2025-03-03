using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class animationHandler : MonoBehaviour
{
    //element 0 is default frame
    //element 1 is one foot up frame
    //element 2 is second foot up frame
    public Material[] clothesLeft;
    public Material[] clothesRight;
    //0 and 1 are left and left blink 2 and 3 are right and right blink
    public Material[] skin;
    //element 0 is left, element 1 is right
    public Material[] hair;
    public GlobalVariables GV;
    private Renderer clothesRend;
    private Renderer skinRend;
    private Renderer hairRend;
    private bool isWalkingLeft = false;
    private bool isWalkingRight = false;
    private bool isFacingLeft = true;
    private bool isFacingRight = false;


    
    void Start()
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
        StartCoroutine(blinkingLoop());
    }

    // Update is called once per frame
    void Update()
    {
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
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(!isFacingLeft)
            {
                isWalkingRight = true;
                StartCoroutine(walkingRightAnimation());

            }else{
                isWalkingLeft = true;
                StartCoroutine(walkingLeftAnimation());
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(!isFacingLeft)
            {
                isWalkingRight = true;
                StartCoroutine(walkingRightAnimation());
            }else{
                isWalkingLeft = true;
                StartCoroutine(walkingLeftAnimation());
            }
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            if(isWalkingRight)
            {
                isWalkingRight = false;
            }else if(isWalkingLeft){
                isWalkingLeft = false;
            }
            
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            if(isWalkingRight)
            {
                isWalkingRight = false;
            }else if(isWalkingLeft){
                isWalkingLeft = false;
            }
        }
        
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
