using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCharacterMaterials : MonoBehaviour
{

    public Material[] skinMale1;
    public Material[] skinMale2;
    public Material[] skinMale3;
    public Material[] skinMale4;
    public Material[] skinFemale1;
    public Material[] skinFemale2;
    public Material[] skinFemale3;
    public Material[] skinFemale4;
    //0 is look left eyes open mouth close      3 is look right eyes open mouth close
    //1 is look left eyes close mouth close     4 is look right eyes close mouth close
    //2 is look left eyes open mouth open       5 is look right eyes open mouth open

    public Material[] scrubs;
    //0 is look left                    //3 is look right
    //1 is look left leg up frame 1     //4 is look right leg up frame 1
    //2 is look left leg up frame 2     //5 is look right leg up frame 2
    public Material[] glasses;
    //0 is look left 1 is look right
    public Material[] labCoat;
    //0 is look left 1 is look right;
    public Material[] hairShort;
    //0 is look left 1 is look right;
    public Material[] hairPonytail;
    //0 is look let 1 is look right;
    public Material blankMat;
    
    public Material[] getSkinMaterial(int sexID, int skinID)
    {
        Material[] skinReturn = new Material[6];
        if(sexID == 1)
        {
            Debug.Log("" + sexID);
            //Male
            if(skinID == 0)
            {
                skinReturn = skinMale1;
            }else if(skinID == 1){
                skinReturn = skinMale2;
            }else if(skinID == 2){
                skinReturn = skinMale3;
            }else if(skinID == 3){
                skinReturn = skinMale4;
            }
        }else if(sexID == 2){
            //Female
            if(skinID == 0)
            {
                skinReturn = skinFemale1;
            }else if(skinID == 1){
                skinReturn = skinFemale2;
            }else if(skinID == 2){
                skinReturn = skinFemale3;
            }else if(skinID == 3){
                skinReturn = skinFemale4;
            }
        }
        Debug.Log(skinReturn.Length);
        return skinReturn;
    }
    public Material[] getHair(int hairID, int colorID)
    {
        Material[] hairReturn = new Material[2];
        Color newColor = Color.white;
        if(hairID == 0)
        {
            //bald
            hairReturn[0] = blankMat;
            hairReturn[1] = blankMat;
        }else if(hairID == 1){
            //short
            if(colorID == 0){
                //black
                //373637
                newColor = HexToColor("373637");
                
            }else if(colorID == 1){
                //blonde
                //FEFFB2
                newColor = HexToColor("FEFFB2");
            }else if(colorID == 2){
                //brown
                //603e23
                newColor = HexToColor("603E23");
            }else if(colorID == 3){
                //orange
                //f78f00
                newColor = HexToColor("F78F00");
            }else if(colorID == 4){
                //red
                //f70000
                newColor = HexToColor("F70000");
            }
            hairReturn = hairShort;
            Debug.Log(hairReturn.Length);
            hairReturn[0].color = newColor;
            hairReturn[1].color = newColor;
        
        }else if(hairID == 2){
            //ponytail
            if(colorID == 0)
            {
                //black
                newColor = HexToColor("373637");
            }else if(colorID == 1){
                //blonde
                newColor = HexToColor("FEFFB2");
            }else if(colorID == 2){
                //brown
                newColor = HexToColor("603E23");
            }else if(colorID == 3){
                //orange
                newColor = HexToColor("F78F00");
            }else if(colorID == 4){
                //red
                newColor = HexToColor("F70000");
            }
            hairReturn = hairPonytail;
            hairReturn[0].color = newColor;
            hairReturn[1].color = newColor;
        }
        return hairReturn;
    }
    public Material[] getGlasses(int glassesID)
    {
        Material[] glassesRet = new Material[2];
        if(glassesID == 0)
        {
            glassesRet[0] = blankMat;
            glassesRet[1] = blankMat;
        }else{
            glassesRet = glasses;
        }
        return glassesRet;
    }
    public Material[] getLabcoat(int labcoat)
    {
        Material[] labcoatRet = new Material[2];
        if(labcoat == 0)
        {
            labcoatRet[0] = blankMat;
            labcoatRet[1] = blankMat;
        }else if(labcoat == 1){
            labcoatRet = labCoat;
        }
        return labcoatRet;
    }
    public Material[] getScrubs(int colorID)
    {
        Material[] scrubRet = new Material[6];
        Color newColor = Color.white;
        if(colorID == 0)
        {
            //cyan
            //01e1ff
            newColor = HexToColor("01E1FF");
        }else if(colorID == 1){
            //black
            //000000
            newColor = HexToColor("000000");
        }else if(colorID == 2){
            //grey
            //8a8a8a
            newColor = HexToColor("8A8A8A");
        }else if(colorID == 3){
            //blue or indigo
            //4c00ff
            newColor = HexToColor("4C00FF");
        }else if(colorID == 4){
            //orange
            //ff9500
            newColor = HexToColor("FF9500");
        }else if(colorID == 5){
            //purple
            //d900ff
            newColor = HexToColor("D900FF");
        }else if(colorID == 6){
            //pink
            //ff00bb
            newColor = HexToColor("FF00BB");
        }else if(colorID == 7){
            //red
            //ff0034
            newColor = HexToColor("FF0034");
        }else if(colorID == 8){
            //white
            //ffffff
            newColor = HexToColor("FFFFFF");
        }else if(colorID == 9){
            //yellow
            //d9df00
            newColor = HexToColor("D9DF00");
        }
        for(int i = 0; i < 6; i++)
        {
            scrubs[i].color = newColor;
        }
        scrubRet = scrubs;
        return scrubRet;
    }
    private Color HexToColor(string hex)
    {
        if(ColorUtility.TryParseHtmlString("#" + hex, out Color color))
        {
            return color;
        }
        Debug.Log("Color error");
        return Color.white;
    }
    
    
}
