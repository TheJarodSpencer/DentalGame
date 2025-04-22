using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{

    //public material color changes for animation
    /*
    public Color clothesColor;
    public Color skinColor;
    public Color hairColor;

    public int testCharacterID = 0;
    public GlobalVariables gv;
    public GameObject character;
    public Material[] maleSkinMat;
    public Material[] maleSkinMatBlink;
    public Material[] femaleSkinMat;
    public Material[] femaleSkinMatBlink;
    public Material[] shortHairMat;
    public Material[] ponytailMat;
    public Material noneHairMat;
    public Material[] clothesColorMat;
    public Material labcoatMat;
    public Material glassesMat;
    
    void Start()
    {
        testCharacterID = PlayerSaveData.Instance.GetPlayerCustomization();
        UpdateCharacterAppearance();
    }

    void Update()
    {
        //Updated every frame
        if(character != null)
        {
            UpdateCharacterAppearance();
        }

    }

    void UpdateCharacterAppearance()
    {
        Transform skin = character.transform.Find("skin");
        if(skin != null)
        {
            Renderer renderer = skin.GetComponent<Renderer>();
            if(renderer != null)
            {
                if(idDecoder(1) == 1)
                {
                    renderer.material = maleSkinMat[idDecoder(4)];
                    skinColor = renderer.material.color;
                }else if(idDecoder(1) == 2){
                    renderer.material = femaleSkinMat[idDecoder(4)];
                    skinColor = renderer.material.color;
                }
            }
        }
        Transform hair = character.transform.Find("hair");
        if(hair != null)
        {
            Renderer renderer = hair.GetComponent<Renderer>();
            if(renderer != null)
            {
                if(idDecoder(2) == 0)
                {
                    renderer.material = noneHairMat;
                }else if(idDecoder(2) == 1){
                    renderer.material = shortHairMat[idDecoder(3)];
                }else if(idDecoder(2) == 2){
                    renderer.material = ponytailMat[idDecoder(3)];
                }
            }
        }
        Transform scrub = character.transform.Find("clothes");
        if(scrub != null)
        {
            Renderer renderer = scrub.GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.material = clothesColorMat[idDecoder(5)];
            }
        }
        if(idDecoder(6) == 1)
        {
            Transform labcoatT = character.transform.Find("labcoat");
            if(labcoatT != null)
            {
                Renderer renderer = labcoatT.GetComponent<Renderer>();
                if(renderer != null)
                {
                    renderer.material = labcoatMat;
                }
            }
        }
        if(idDecoder(7) == 1)
        {
            Transform glass = character.transform.Find("glasses");
            if(glass != null)
            {
                Renderer renderer = glass.GetComponent<Renderer>();
                if(renderer != null)
                {
                    renderer.material = glassesMat;
                }
            }
        }
    }


    private int idDecoder(int part)
    {

        //string id = gv.getCharacterID().ToString();
        string id = testCharacterID.ToString();
        int[] idArray = new int[id.Length];
        for(int i = 0; i < id.Length; i++)
        {
            idArray[i] = (int)char.GetNumericValue(id[i]);
        }
        int returner = 0;
        if(part == 1)
        {
            //sex
            returner = idArray[0];
        }else if(part == 2){
            //hair
            returner = idArray[1];
        }else if(part == 3){
            //hair color
            returner = idArray[2];
        }else if(part == 4){
            //skin
            returner = idArray[3];
        }else if(part == 5){
            //scrubs color
            returner = idArray[4];
        }else if(part == 6){
            //labcoat
            returner = idArray[5];
        }else if(part == 7){
            //glasses
            returner = idArray[6];
        }else{
            //add a crasher?
        }
        return returner;
    }
    */
}
