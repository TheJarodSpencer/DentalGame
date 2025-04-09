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
    
    /*
    //THIS SCRIPT IS USED FOR STORING AND GIVING MATERIALS FOR ANIMATIONS FOR THE CHARACTER
    public Material[] WhiteScrubs;
    public Material[] BlueScrubs;
    public Material[] BlackScrubs;
    public Material[] GreyScrubs;
    public Material[] IndigoScrubs;
    public Material[] OrangeScrubs;
    public Material[] PurpleScrubs;
    public Material[] PinkScrubs;
    public Material[] RedScrubs;
    public Material[] YellowScrubs;
    //0 and 1 are two transparents, then left coat and right coat
    public Material[] labcoat;
    //0 and 1 are two transparents, then left glasses and right glasses
    public Material[] glasses;
    //0 and 1 are black left and right
    //2 and 3 are blonde left and right
    //4 and 5 are burnette left and right
    //6 and 7 are orange left and right
    //8 and 9 are red left and right
    //10 is transparent.
    public Material[] ponytail;
    public Material[] shorthair;
    public Material[] noHair;
    //0 and 1 are are skin 1 left and right
    //2 and 3 are skin 2 left and right
    //4 and 5 are skin 3 left and right
    //6 and 7 are skin 4 left and right
    public Material[] skinBlinkMale;
    public Material[] skinMale;
    public Material[] skinBlinkFemale;
    public Material[] skinFemale;
    private Material[] finalScrubs;
    private Material[] finalHair;
    private Material[] finalLabcoat;
    private Material[] finalGlasses;
    private Material[] finalSkinBlink;
    //finalSkin: 0 left 1 left blink 2 right 3 right blink
    private Material[] finalSkin;
    
    public void setScrubColor(int scrubID)
    {
        if(scrubID == 0)
        {
            finalScrubs = BlueScrubs;
        }else if(scrubID == 1){
            finalScrubs = BlackScrubs;
        }else if(scrubID == 2){
            finalScrubs = GreyScrubs;
        }else if(scrubID == 3){
            finalScrubs = IndigoScrubs;
        }else if(scrubID == 4){
            finalScrubs = OrangeScrubs;
        }else if(scrubID == 5){
            finalScrubs = PurpleScrubs;
        }else if(scrubID == 6){
            finalScrubs = PinkScrubs;
        }else if(scrubID == 7){
            finalScrubs = RedScrubs;
        }else if(scrubID == 8){
            finalScrubs = WhiteScrubs;
        }else if(scrubID == 9){
            finalScrubs = YellowScrubs;
        }

    }
    public Material[] getScrubColor()
    {
        return finalScrubs;
    }
    public void setHairColor(int hairID, int hairColorID)
    {
        if(hairID == 0)
        {
            finalHair = noHair;
        }else if(hairID == 1){
            if(hairColorID == 0)
            {
                finalHair[0] = shorthair[0];
                finalHair[1] = shorthair[1];
            }else if(hairColorID == 1){
                finalHair[0] = shorthair[2];
                finalHair[1] = shorthair[3];
            }else if(hairColorID == 2){
                finalHair[0] = shorthair[4];
                finalHair[1] = shorthair[5];
            }else if(hairColorID == 3){
                finalHair[0] = shorthair[6];
                finalHair[1] = shorthair[7];
            }else if(hairColorID == 4){
                finalHair[0] = shorthair[8];
                finalHair[1] = shorthair[9];
            }
        }else if(hairID == 2){
            if(hairColorID == 0)
            {
                finalHair[0] = ponytail[0];
                finalHair[1] = ponytail[1];
            }else if(hairColorID == 1){
                finalHair[0] = ponytail[2];
                finalHair[1] = ponytail[3];
            }else if(hairColorID == 2){
                finalHair[0] = ponytail[4];
                finalHair[1] = ponytail[5];
            }else if(hairColorID == 3){
                finalHair[0] = ponytail[6];
                finalHair[1] = ponytail[7];
            }else if(hairColorID == 4){
                finalHair[0] = ponytail[8];
                finalHair[1] = ponytail[9];
            }
        }
        
    }
    public Material[] getHairColor()
    {
        return finalHair;
    }
    public void setLabcoat(int labcoatID)
    {
        if(labcoatID == 0)
        {
            finalLabcoat[0] = labcoat[0];
            finalLabcoat[1] = labcoat[1];
        }else if(labcoatID == 1){
            finalLabcoat[0] = labcoat[2];
            finalLabcoat[1] = labcoat[3];
        }
    }
    public Material[] getLabcoat()
    {
        return finalLabcoat;
    }
    public void setGlasses(int glassesID)
    {
        if(glassesID == 0)
        {
            finalGlasses[0] = glasses[0];
            finalGlasses[1] = glasses[1];
        }else if(glassesID == 1){
            finalGlasses[0] = glasses[2];
            finalGlasses[1] = glasses[3];
        }
    }
    public Material[] getGlasses()
    {
        return finalGlasses;
    }
    public void setSkin(int skinID, int sexID)
    {
        if(sexID == 1)
        {
            if(skinID == 0)
            {
                finalSkin[0] = skinMale[0];
                finalSkin[1] = skinMale[1];
                finalSkinBlink[0] = skinBlinkMale[0];
                finalSkinBlink[1] = skinBlinkMale[1];
            }else if(skinID == 1){
                finalSkin[0] = skinMale[2];
                finalSkin[1] = skinMale[3];
                finalSkinBlink[0] = skinBlinkMale[2];
                finalSkinBlink[1] = skinBlinkMale[3]; 
            }else if(skinID == 2){
                finalSkin[0] = skinMale[4];
                finalSkin[1] = skinMale[5];
                finalSkinBlink[0] = skinBlinkMale[4];
                finalSkinBlink[1] = skinBlinkMale[5];
            }else if(skinID == 3){
                finalSkin[0] = skinMale[6];
                finalSkin[1] = skinMale[7];
                finalSkinBlink[0] = skinBlinkMale[6];
                finalSkinBlink[1] = skinBlinkMale[7];
            }
        }else if(sexID == 2){
            if(skinID == 0)
            {
                finalSkin[0] = skinFemale[0];
                finalSkin[1] = skinFemale[1];
                finalSkinBlink[0] = skinBlinkFemale[0];
                finalSkinBlink[1] = skinBlinkFemale[1];
            }else if(skinID == 1){
                finalSkin[0] = skinFemale[2];
                finalSkin[1] = skinFemale[3];
                finalSkinBlink[0] = skinBlinkFemale[2];
                finalSkinBlink[1] = skinBlinkFemale[3]; 
            }else if(skinID == 2){
                finalSkin[0] = skinFemale[4];
                finalSkin[1] = skinFemale[5];
                finalSkinBlink[0] = skinBlinkFemale[4];
                finalSkinBlink[1] = skinBlinkFemale[5];
            }else if(skinID == 3){
                finalSkin[0] = skinFemale[6];
                finalSkin[1] = skinFemale[7];
                finalSkinBlink[0] = skinBlinkFemale[6];
                finalSkinBlink[1] = skinBlinkFemale[7];
            }
        }
    }
    public Material[] getSkin()
    {
        return finalSkin;
    }
    public Material[] getSkinBlink()
    {
        return finalSkinBlink;
    }
    */
}
