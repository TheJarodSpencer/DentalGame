using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCharacterMaterials : MonoBehaviour
{
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
    public Material[] skinBlinkFemale = new Material[2];
    public Material[] skinFemale = new Material[2];
    private Material[] finalScrubs;
    private Material[] finalHair = new Material[2];
    private Material[] finalLabcoat = new Material[2];
    private Material[] finalGlasses = new Material[2];
    private Material[] finalSkinBlink = new Material[2];
    //finalSkin: 0 left 1 left blink 2 right 3 right blink
    private Material[] finalSkin = new Material[2];
    
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
        Debug.Log("skinID: " + skinID + "sexID: " + sexID);
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
}
