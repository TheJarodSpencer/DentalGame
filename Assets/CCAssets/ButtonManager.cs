using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //Character objects
    public GameObject character;
    //prefab materials
    public Material[] shortHairMat;
    public Material[] ponytailHairMat;
    public Material[] maleSkinMat;
    public Material[] femaleSkinMat;
    public Material[] clothesColorMat;
    public Material labcoatMat;
    public Material glassesMat;

    //Character ID: 
    //first digit = sexID: 1=male 2=female
    //second digit = hairID: 0=none, 1=short, 2=ponytail
    //third digit = hairColorID: 0=black, 1=blonde, 2=brown, 3=orange, 4=red
    //fourth digit = skinID
    //fifth digit = clothesColorID: 0=cyan, 1=black, 2=grey, 3=blue, 4=orange, 5=purple, 6=pink,7=red, 8=white, 9=yellow.
    //sixth digit = labcoat bool: 0=no 1=yes
    //seventh digit = glasses bool: 0=no 1=yes
    int characterID = 1111200;
    //Basebuttons
    public Button sexButton;
    public Button hairButton;
    public Button skinButton;
    public Button clothesButton;
    public Button backButton;
    public Button submitButton;
    //Sex buttons lol
    public Button maleButton;
    public Button femaleButton;
    public GameObject sexEmpty;
    //Hair buttons
    public GameObject hairEmpty;
    //Buttons for style
    public Button ponytailButton;
    public Button noneButton;
    public Button shortButton;
    //hair color buttons
    public Button blackHairButton;
    public Button blondeHairButton;
    public Button orangeHairButton;
    public Button redHairButton;
    //Skin buttons
    public GameObject skinEmpty;
    public Button skinColor1;
    public Button skinColor2;
    public Button skinColor3;
    public Button skinColor4;
    //clothes buttons
    public GameObject clothesEmpty;
    //style buttons
    public Button labcoat;
    public Button glasses;
    //scrubs color buttons
    public Button blueScrubs;
    public Button blackScrubs;
    public Button greyScrubs;
    public Button indigoScrubs;
    public Button orangeScrubs;
    public Button purpleScrubs;
    public Button pinkScrubs;
    public Button redScrubs;
    public Button whiteScrubs;
    public Button yellowScrubs;
    //blue button color: 3BFFE6
    //green button color: 3BFF5B
    private Color blueButton = new Color(0.235f, 1f, 0.894f);
    private Color greenButton = new Color(0.235f, 1f, 0.356f);
    void Start()
    {
        //Default appearance: Hair none, sex male, skin 1, clothes no labcoat or glasses grey scrubs
        //Set buttons pertaining this to be green
        
        

        //Set everything to be invisible
        sexEmpty.SetActive(false);
        hairEmpty.SetActive(false);
        skinEmpty.SetActive(false);
        clothesEmpty.SetActive(false);

        //Add the button listeners
        sexButton.onClick.AddListener(sexButtonOnClick);
        hairButton.onClick.AddListener(hairButtonOnClick);
        skinButton.onClick.AddListener(skinButtonOnClick);
        clothesButton.onClick.AddListener(clothesButtonOnClick);

    }


    void Update()
    {
        
    }

    void sexButtonOnClick()
    {
        sexEmpty.SetActive(true);
        hairEmpty.SetActive(false);
        skinEmpty.SetActive(false);
        clothesEmpty.SetActive(false);
        //change button colors
        sexButton.GetComponent<Image>().color = greenButton;
        hairButton.GetComponent<Image>().color = blueButton;
        skinButton.GetComponent<Image>().color = blueButton;
        clothesButton.GetComponent<Image>().color = blueButton;
        //addlisteners for sex buttons
        maleButton.onClick.AddListener(maleButtonOnClick);
        femaleButton.onClick.AddListener(femaleButtonOnClick);
        if(idDecoder(1) == 1)
        {
            maleButton.GetComponent<Image>().color = greenButton;
            femaleButton.GetComponent<Image>().color = blueButton;
        }else if(idDecoder(1) == 2){
            maleButton.GetComponent<Image>().color = blueButton;
            femaleButton.GetComponent<Image>().color = greenButton;
        }

    }

    public void hairButtonOnClick()
    {
        sexEmpty.SetActive(false);
        hairEmpty.SetActive(true);
        skinEmpty.SetActive(false);
        clothesEmpty.SetActive(false);
        //change button colors
        sexButton.GetComponent<Image>().color = blueButton;
        hairButton.GetComponent<Image>().color = greenButton;
        skinButton.GetComponent<Image>().color = blueButton;
        clothesButton.GetComponent<Image>().color = blueButton;
        //add listeners
        noneButton.onClick.AddListener(noneButtonOnClick);
        //shortButton.onClick.AddListener(shortButtonOnClick);
        //ponytailButton.onClick.AddListener(ponytailButtonOnClick);
        //make sure the correct hair is highlighted
        if(idDecoder(2) == 0)
        {
            noneButton.GetComponent<Image>().color = greenButton;
            shortButton.GetComponent<Image>().color = blueButton;
            ponytailButton.GetComponent<Image>().color = blueButton;
        }else if(idDecoder(2) == 1){
            noneButton.GetComponent<Image>().color = blueButton;
            shortButton.GetComponent<Image>().color = greenButton;
            ponytailButton.GetComponent<Image>().color = blueButton;
        }else if(idDecoder(2) == 2){
            noneButton.GetComponent<Image>().color = blueButton;
            shortButton.GetComponent<Image>().color = blueButton;
            ponytailButton.GetComponent<Image>().color = greenButton;
        }
    }
    
    public void skinButtonOnClick()
    {
        sexEmpty.SetActive(false);
        hairEmpty.SetActive(false);
        skinEmpty.SetActive(true);
        clothesEmpty.SetActive(false);
        //change button colors
        sexButton.GetComponent<Image>().color = blueButton;
        hairButton.GetComponent<Image>().color = blueButton;
        skinButton.GetComponent<Image>().color = greenButton;
        clothesButton.GetComponent<Image>().color = blueButton;
    }

    public void clothesButtonOnClick()
    {
        sexEmpty.SetActive(false);
        hairEmpty.SetActive(false);
        skinEmpty.SetActive(false);
        clothesEmpty.SetActive(true);
        //change button colors
        sexButton.GetComponent<Image>().color = blueButton;
        hairButton.GetComponent<Image>().color = blueButton;
        skinButton.GetComponent<Image>().color = blueButton;
        clothesButton.GetComponent<Image>().color = greenButton;
    }

    //Sex sub-buttons
    public void maleButtonOnClick()
    {
        //change button color
        maleButton.GetComponent<Image>().color = greenButton;
        femaleButton.GetComponent<Image>().color = blueButton;
        //set to male
        Transform skin = character.transform.Find("skin");
        if(skin != null)
        {
            Renderer renderer = skin.GetComponent<Renderer>();

            if(renderer != null)
            {
                renderer.material = maleSkinMat[idDecoder(4) - 1];
            }
        }
        //update the ID
        idUpdater(1, 1);

    }
    public void femaleButtonOnClick()
    {
        maleButton.GetComponent<Image>().color = blueButton;
        femaleButton.GetComponent<Image>().color = greenButton;
        //set to female
        Transform skin = character.transform.Find("skin");
        if(skin != null)
        {
            Renderer renderer = skin.GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.material = femaleSkinMat[idDecoder(4) - 1];
            }
        }
        idUpdater(1, 2);
    }

    //Hair subbuttons

    public void noneButtonOnClick()
    {
        noneButton.GetComponent<Image>().color = greenButton;
        shortButton.GetComponent<Image>().color = blueButton;
        ponytailButton.GetComponent<Image>().color = blueButton;
        Transform hair = character.transform.Find("hair");
        if(hair != null)
        {
            Renderer renderer = hair.GetComponent<Renderer>();
            if(renderer!= null)
            {
                //renderer.enabled = false;
                //create an invisible material
            }
        }
        idUpdater(2, 0);
    }
    public void shortButtonOnClick()
    {
        noneButton.GetComponent<Image>().color = blueButton;
        shortButton.GetComponent<Image>().color = greenButton;
        ponytailButton.GetComponent<Image>().color = blueButton;
        Transform hair = character.transform.Find("hair");
        if(hair != null)
        {
            Renderer renderer = hair.GetComponent<Renderer>();
            renderer.enabled = true;
            if(renderer != null)
            {

                renderer.material = shortHairMat[idDecoder(3)];
            }
        }
    }
    //THESE EDIT AND TRANSLATE THE ID CODES

    private int idDecoder(int part)
    {

        string id = characterID.ToString();
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
    private void idUpdater(int part, int newValue)
    {
        string id = characterID.ToString();
        int[] idArray = new int[id.Length];
        for(int i = 0; i < id.Length; i++)
        {
            idArray[i] = (int)char.GetNumericValue(id[i]);
        }

        if(part == 1)
        {
            //sex
            idArray[0] = newValue;
        }else if(part == 2){
            //hair
            idArray[1] = newValue;
        }else if(part == 3){
            //hair color
            idArray[2] = newValue;
        }else if(part == 4){
            //skin
            idArray[3] = newValue;
        }else if(part == 5){
            //scrubs color
            idArray[4] = newValue;
        }else if(part == 6){
            //labcoat
            idArray[5] = newValue;
        }else if(part == 7){
            //glasses
            idArray[6] = newValue;
        }else{
            //add a crasher?
        }
        string newID = "";
        for(int i = 0; i < id.Length; ++i)
        {
            newID += idArray[i].ToString();
        }

        characterID = int.Parse(newID);

    }
    

}
