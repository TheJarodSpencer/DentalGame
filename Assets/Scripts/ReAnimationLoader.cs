using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReAnimationLoader : MonoBehaviour
{
    public GlobalCharacterMaterials GCM;
    public GlobalVariables GV;
    public Material[] skin;
    public Material[] scrubs;
    public Material[] hair;
    public Material[] glasses;
    public Material[] labcoat;
    // Start is called before the first frame update
    void Start()
    {
        //ADD HERE WHATEVER YOU NEED TO GRAB CHARACTER ID
        int id = GV.getCharacterID();
        string ids = "" + id;
        char[] charID = ids.ToCharArray();
        string converter = charID[0] + "";
        int sexID = Int32.Parse(converter);
        converter = charID[3] + "";
        int skinID = Int32.Parse(converter);
        skin = GCM.getSkinMaterial(sexID, skinID);
        converter = charID[1] + "";
        int hairID = Int32.Parse(converter);
        converter = charID[2] + "";
        int hairColorID = Int32.Parse(converter);
        hair = GCM.getHair(hairID, hairColorID);
        converter = charID[6] + "";
        int glassesID = Int32.Parse(converter);
        glasses = GCM.getGlasses(glassesID);
        converter = charID[5] + "";
        int labcoatID = Int32.Parse(converter);
        labcoat = GCM.getLabcoat(labcoatID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
