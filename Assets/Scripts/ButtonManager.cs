using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //Character objects
    public GameObject character;
    //prefab materials
    public Material noneHairMat;
    public Material[] shortHairMat;
    public Material[] ponytailHairMat;
    public Material[] maleSkinMat;
    public Material[] maleSkinMatBlink;
    public Material[] femaleSkinMat;
    public Material[] femaleSkinMatBlink;
    public Material[] clothesColorMat;
    public Material labcoatMat;
    public Material glassesMat;
    //this contains the character id that will be sent
    public GlobalVariables gv;
    //Basebuttons
    public Button sexButton;
    public Button hairButton;
    public Button skinButton;
    public Button clothesButton;
    //Sex buttons
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
    public Button brownHairButton;
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
        //starts blinking animation
        StartCoroutine(BlinkingLoop());
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
    //blinking animation
    private IEnumerator BlinkingLoop()
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
        Transform skin = character.transform.Find("skin");
        if(skin != null)
        {
            Renderer renderer = skin.GetComponent<Renderer>();
            if(renderer != null)
            {
                if(idDecoder(1) == 1)
                {
                    renderer.material = maleSkinMatBlink[idDecoder(4)];
                }else if(idDecoder(1) == 2){
                    renderer.material = femaleSkinMatBlink[idDecoder(4)];
                }
            }
        }
    }
    private void unblink()
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
                }else if(idDecoder(1) == 2){
                    renderer.material = femaleSkinMat[idDecoder(4)];
                }
            }
        }
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
        shortButton.onClick.AddListener(shortButtonOnClick);
        ponytailButton.onClick.AddListener(ponytailButtonOnClick);
        blackHairButton.onClick.AddListener(blackHairButtonOnClick);
        blondeHairButton.onClick.AddListener(blondeHairButtonOnClick);
        brownHairButton.onClick.AddListener(brownHairButtonOnClick);
        orangeHairButton.onClick.AddListener(orangeHairButtonOnClick);
        redHairButton.onClick.AddListener(redHairButtonOnClick);
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
        //add listeners
        skinColor1.onClick.AddListener(skinColor1OnClick);
        skinColor2.onClick.AddListener(skinColor2OnClick);
        skinColor3.onClick.AddListener(skinColor3OnClick);
        skinColor4.onClick.AddListener(skinColor4OnClick);
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
        //add listeners
        labcoat.onClick.AddListener(labcoatOnClick);
        glasses.onClick.AddListener(glassesOnClick);
        blueScrubs.onClick.AddListener(blueScrubsOnClick);
        blackScrubs.onClick.AddListener(blackScrubsOnClick);
        greyScrubs.onClick.AddListener(greyScrubsOnClick);
        indigoScrubs.onClick.AddListener(indigoScrubsOnClick);
        orangeScrubs.onClick.AddListener(orangeScrubsOnClick);
        purpleScrubs.onClick.AddListener(purpleScrubsOnClick);
        pinkScrubs.onClick.AddListener(pinkScrubsOnClick);
        redScrubs.onClick.AddListener(redScrubsOnClick);
        whiteScrubs.onClick.AddListener(whiteScrubsOnClick);
        yellowScrubs.onClick.AddListener(yellowScrubsOnClick);
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
                renderer.material = maleSkinMat[idDecoder(4)];
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
                renderer.material = femaleSkinMat[idDecoder(4)];
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
                renderer.material = noneHairMat;
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
            if(renderer != null)
            {
                renderer.material = shortHairMat[idDecoder(3)];
            }

        }
        idUpdater(2, 1);
    }

    public void ponytailButtonOnClick()
    {
        noneButton.GetComponent<Image>().color = blueButton;
        shortButton.GetComponent<Image>().color = blueButton;
        ponytailButton.GetComponent<Image>().color = greenButton;
        Transform hair = character.transform.Find("hair");
        if(hair != null)
        {
            Renderer renderer = hair.GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.material = ponytailHairMat[idDecoder(3)];
            }
        }
        idUpdater(2, 2);
    }
    
    //hair color buttons
    public void blackHairButtonOnClick()
    {
        hairColorUpdater(0);
    }
    public void blondeHairButtonOnClick()
    {
        hairColorUpdater(1);
    }
    public void brownHairButtonOnClick()
    {
        hairColorUpdater(2);
    }
    public void orangeHairButtonOnClick()
    {
        hairColorUpdater(3);
    }
    public void redHairButtonOnClick()
    {
        hairColorUpdater(4);
    }
    private void hairColorUpdater(int hairColor)
    {
        if(idDecoder(2) != 0)
        {
            Transform hair = character.transform.Find("hair");
            if(hair != null)
            {
                Renderer renderer = hair.GetComponent<Renderer>();
                if(renderer != null)
                {
                    if(idDecoder(2) == 1)
                    {
                        renderer.material = shortHairMat[hairColor];
                    }else if(idDecoder(2) == 2){
                        renderer.material = ponytailHairMat[hairColor];
                    }
                }
            }
            idUpdater(3, hairColor);
        }
    }
    //skin buttons
    public void skinColor1OnClick()
    {
        skinColorChanger(0);
    }
    public void skinColor2OnClick()
    {
        skinColorChanger(1);
    }
    public void skinColor3OnClick()
    {
        skinColorChanger(2);
    }
    public void skinColor4OnClick()
    {
        skinColorChanger(3);
    }
    private void skinColorChanger(int skincolor)
    {
        Transform skin = character.transform.Find("skin");
        if(skin != null)
        {
            Renderer renderer = skin.GetComponent<Renderer>();
            if(renderer != null)
            {
                if(idDecoder(1) == 1)
                {
                    //male skins
                    renderer.material = maleSkinMat[skincolor];
                }else if(idDecoder(1) == 2){
                    //female skins
                    renderer.material = femaleSkinMat[skincolor];
                }
            }
        }
        idUpdater(4, skincolor);
    }
    //Glasses and labcoat changers
    public void labcoatOnClick()
    {
        Transform labcoatT = character.transform.Find("labcoat");
        if(labcoatT != null)
        {
            Renderer renderer = labcoatT.GetComponent<Renderer>();
            if(renderer != null)
            {
                if(idDecoder(6) == 0)
                {
                    renderer.material = labcoatMat;
                    labcoat.GetComponent<Image>().color = greenButton;
                    idUpdater(6, 1);
                }else if(idDecoder(6) == 1){
                    renderer.material = noneHairMat;
                    labcoat.GetComponent<Image>().color = blueButton;
                    idUpdater(6, 0);
                }
            }
        }
    }
    public void glassesOnClick()
    {
        Transform glassesT = character.transform.Find("glasses");
        if(glasses != null)
        {
            Renderer renderer = glassesT.GetComponent<Renderer>();
            if(renderer != null)
            {
                if(idDecoder(7) == 0)
                {
                    renderer.material = glassesMat;
                    glasses.GetComponent<Image>().color = greenButton;
                    idUpdater(7, 1);
                }else if(idDecoder(7) == 1){
                    renderer.material = noneHairMat;
                    glasses.GetComponent<Image>().color = blueButton;
                    idUpdater(7, 0);
                }
            }
        }
    }
    public void blueScrubsOnClick()
    {
        scrubsChanger(0);
    }
    public void blackScrubsOnClick()
    {
        scrubsChanger(1);
    }
    public void greyScrubsOnClick()
    {
        scrubsChanger(2);
    }
    public void indigoScrubsOnClick()
    {
        scrubsChanger(3);
    }
    public void orangeScrubsOnClick()
    {
        scrubsChanger(4);
    }
    public void purpleScrubsOnClick()
    {
        scrubsChanger(5);
    }
    public void pinkScrubsOnClick()
    {
        scrubsChanger(6);
    }
    public void redScrubsOnClick()
    {
        scrubsChanger(7);
    }
    public void whiteScrubsOnClick()
    {
        scrubsChanger(8);
    }
    public void yellowScrubsOnClick()
    {
        scrubsChanger(9);
    }
    private void scrubsChanger(int scrubcolor)
    {
        Transform scrub = character.transform.Find("clothes");
        if(scrub != null)
        {
            Renderer renderer = scrub.GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.material = clothesColorMat[scrubcolor];
            }
        }
        idUpdater(5, scrubcolor);
    }
    //THESE EDIT AND TRANSLATE THE ID CODES

    private int idDecoder(int part)
    {

        string id = gv.getCharacterID().ToString();
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
        string id = gv.getCharacterID().ToString();
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

        gv.setCharacterID(int.Parse(newID));

    }

        //Back button goes to welcome screen
        public void OnBackButton(){
        SceneManager.LoadScene("WelcomeScene");
    }
        //Starting game
        public void OnPlayButton(){
        SceneManager.LoadScene("LevelSelector");
    }

}
