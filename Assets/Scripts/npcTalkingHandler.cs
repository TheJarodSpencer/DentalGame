using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class npcTalkingHandler : MonoBehaviour
{
    //Skins should be left, left blink, right, right blink, left talk, right talk
    public Material[] skins;
    //0 is left, 1 is right
    public Material[] clothes;
    public Material[] hair;
    public Material[] glasses;
    public GlobalVariables GV;
    
    public Transform player;
    private Vector3 npcPosition;
    private Renderer skinRend;
    private Renderer clothesRend;
    private Renderer glassesRend;
    private Renderer hairRend;

    private bool lookingLeft = true;
    void Start()
    {
        npcPosition = transform.position;
        skinRend = transform.Find("skin").GetComponent<Renderer>();
        clothesRend = transform.Find("clothes").GetComponent<Renderer>();
        glassesRend = transform.Find("glasses").GetComponent<Renderer>();
        hairRend = transform.Find("hair").GetComponent<Renderer>();
        StartCoroutine(talkingAnimation());
        StartCoroutine(blinkingLoop());
    }

    
    void Update()
    {
        //turn right
        if(player.position.x > npcPosition.x)
        {
            lookingLeft = false;
            skinRend.material = skins[2];
            clothesRend.material = clothes[1];
            hairRend.material = hair[1];
            glassesRend.material = glasses[1];
        }else{
            //turn left
            lookingLeft = true;
            skinRend.material = skins[0];
            clothesRend.material = clothes[0];
            hairRend.material = hair[0];
            glassesRend.material = glasses[0];
        }
        
    }
    private IEnumerator talkingAnimation()
    {
        
        float seconds = 0.20f;
        yield return new WaitForSeconds(seconds);
        if(GV.isTalking())
        {
            openMouth();
        }
        yield return new WaitForSeconds(seconds);
        
        closeMouth();
        
    }
    private void openMouth()
    {
        if(lookingLeft)
        {
            skinRend.material = skins[4];
        }else{
            skinRend.material = skins[5];
        }
    }
    private void closeMouth()
    {
        if(lookingLeft)
        {
            skinRend.material = skins[0];
        }else{
            skinRend.material = skins[2];
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
        if(!GV.isTalking())
        {
            if(lookingLeft)
            {
                skinRend.material = skins[1];
            }else{
                skinRend.material = skins[3];
            }
        }
    }
    private void unblink()
    {
        if(!GV.isTalking())
        {
            if(lookingLeft)
            {
                skinRend.material = skins[0];
            }else{
                skinRend.material = skins[2];
            }
        }
    }
}
