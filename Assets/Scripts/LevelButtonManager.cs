using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Text.RegularExpressions;

public class LevelButtonManager : MonoBehaviour
{
    public GlobalVariables GV;

    public chatboxHandler cbh;
    //public TalkingHandler talkingHandlerScript;
    public FireBase FB;
    public KeepPlayerPOS pos;

    //To keep track of a score of 100
    public float score = 0f;
    public int attemptsMed = 0;
    public int attemptsDia = 0;
    public float maxScore = 100f;

    public GameObject axiumUIPanel;
    public GameObject diagnosisButton;
    public GameObject medicineButton;
    public GameObject backButtonFromAxium;
    public GameObject axiumButton;
    public GameObject diagnosisAns;
    public GameObject medicineAns;
    public GameObject backButtonFromDiaAndMed;
    public GameObject completeLevel;
    public GameObject npc;

    //For the Diagnosis and Medicine Anwsers
    public Button[] medButtons;
    public Button[] diaButtons;
    public TextAsset diaFile; 
    public TextAsset medFile;

    //For Score
    public TMP_Text scoreText;

    //For if wrong or right button for Med and Diagnosis
    public int correctDiaAnswerIndex;
    public int correctMedAnswerIndex;
    public bool isDiaCorrect =  false;
    public bool isMedCorrect = false;
    public int correctAnswerDia = 0;
    public int correctAnswerMed = 0;
    public int onlyCountOnceDia = 0;
    public int onlyCountOnceMed = 0;
    private bool[] diaButtonClicked;
    private bool[] medButtonClicked;

    //To disable NPC click
    public GameObject npcHoverDetector;

    //To grab scene name for score
    public string currentSceneName;


    void Start(){
        LoadTextFromFile(diaFile, diaButtons);
        string[] diaLines = diaFile.text.Split('\n');
        correctDiaAnswerIndex = int.Parse(diaLines[0].Trim());
        LoadTextFromFile(medFile, medButtons);
        string[] medLines = medFile.text.Split('\n');
        correctMedAnswerIndex = int.Parse(medLines[0].Trim());
        //diagnosisButton.SetActive(false);

        diaButtonClicked = new bool[diaButtons.Length];
        medButtonClicked = new bool[medButtons.Length];

        for (int i = 0; i < diaButtons.Length; i++)
        {
            int buttonIndex = i; // Capture index
            diaButtons[i].onClick.AddListener(() =>
            {
                if (!diaButtonClicked[buttonIndex])
                {
                    diaButtonClicked[buttonIndex] = true;
                    OnClickColorsTheButtonsDia(diaButtons[buttonIndex], diaButtons, correctDiaAnswerIndex);
                }
            });
        }
        
        for (int i = 0; i < medButtons.Length; i++)
        {
            int buttonIndex = i; // Capture index
            medButtons[i].onClick.AddListener(() =>
            {
                if (!medButtonClicked[buttonIndex])
                {
                    medButtonClicked[buttonIndex] = true;
                    OnClickColorsTheButtonsMed(medButtons[buttonIndex], medButtons, correctMedAnswerIndex);
                }
            });
        }
        //StartCoroutine(UpdateToGrabTheDiaAfterTalk());
    }

    /*
    IEnumerator UpdateToGrabTheDiaAfterTalk()
    {
        while (true) // Run forever (or use a condition to stop)
        {
            if(GV.getAlreadyTalkedTo() == true){
                ActivateDia();
            }
            yield return new WaitForSeconds(1f); 
        }
    }
    */
    
   public int GetLevelNumber()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Current Scene Name: " + currentSceneName);

        //Grab Number of Level
        string numberString = Regex.Match(currentSceneName, @"\d+").Value;
        if (int.TryParse(numberString, out int levelNumber))
        {
            Debug.Log("Extracted Level Number: " + levelNumber);//Check output
            return levelNumber;
        }
        else
        {
            Debug.Log("No valid level number found in the scene name.");
            return 0;
        }
    } 



    public void ActivateDia(){
        diagnosisButton.SetActive(true);
    }

    //Reads the buttons
    void LoadTextFromFile(TextAsset textFile, Button[] buttons){
        string[] lines = textFile.text.Split('\n');

        for(int i = 0; i < buttons.Length && i < lines.Length; i++){
            TMP_Text buttonText = buttons[i].GetComponentInChildren<TMP_Text>();
                if (buttonText != null)
                {
                    buttonText.text = lines[i + 1].Trim(); //Set button text from file
                }

        //Color buttonColor = (i == correctAnswerIndex) ? Color.green : Color.red;
        //buttons[i].GetComponent<Image>().color = buttonColor;
        }

    }

    //Track buttons for DIA
    public void OnClickColorsTheButtonsDia(Button clickedButton, Button[] buttons, int correctAnswerIndex){
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if ((buttonIndex == correctAnswerIndex) && (onlyCountOnceDia == 0))
        {
            onlyCountOnceDia++;
            clickedButton.GetComponent<Image>().color = Color.green; //Correct
            isDiaCorrect = true;
            float rewardMultiplier = attemptsDia == 0 ? 0.5f : 
                                 attemptsDia == 1 ? 0.25f : 
                                 attemptsDia == 2 ? 0.1875f : 
                                 0.125f;
            score += maxScore * rewardMultiplier;//Maxscore times how much they earned + already exsisting score
        }
        else if(onlyCountOnceDia == 1){
            return;
        }
        else if(attemptsDia <= 4)
        {
            attemptsDia++;//Each attempt wrong attempt is tracked
            clickedButton.GetComponent<Image>().color = Color.red; //Wrong
            Debug.Log("Wrong answer!");
        }
        else{
            return;
        }
    }

    //Track the buttons for MED
    public void OnClickColorsTheButtonsMed(Button clickedButton, Button[] buttons, int correctAnswerIndex){
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if ((buttonIndex == correctAnswerIndex) && (onlyCountOnceMed == 0))
        {
            onlyCountOnceMed++;
            clickedButton.GetComponent<Image>().color = Color.green; //Correct
            isMedCorrect = true;
            float rewardMultiplier = attemptsMed == 0 ? 0.5f : 
                                 attemptsMed == 1 ? 0.25f : 
                                 attemptsMed == 2 ? 0.1875f : 
                                 0.125f;
            score += maxScore * rewardMultiplier;//Maxscore times how much they earned + already exsisting score
        }
        else if(onlyCountOnceMed == 1){
            return;
        }
        else if(attemptsMed <= 4)
        {
            attemptsMed++;//Each attempt wrong attempt is tracked
            clickedButton.GetComponent<Image>().color = Color.red; //Wrong
            Debug.Log("Wrong answer!");
        }
        else{
            return;
        }
    }

    //Output the score
    public void CalculationOfDiaAndMed(){
        axiumUIPanel.SetActive(false);
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        backButtonFromAxium.SetActive(false);
        axiumButton.SetActive(false);
        diagnosisAns.SetActive(false);
        medicineAns.SetActive(false);
        backButtonFromDiaAndMed.SetActive(false);
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        npc.SetActive(false);
        completeLevel.SetActive(true);

        scoreText.text = score.ToString() + "%";
        Debug.Log("In LBM: "+ GetLevelNumber());

        FB.UpdateCharacterField("playerExperience", score);

        Debug.Log("Correct answer!");
        attemptsMed = 0;//Reset for next button set
        attemptsDia = 0;
        isDiaCorrect = false;
        isMedCorrect = false;
    }

    public void OnClickOfAxium(){
        GV.setCheckedAxium(true);
        cbh.canFLip = true;
        axiumUIPanel.SetActive(true);
        backButtonFromAxium.SetActive(true); 
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        axiumButton.SetActive(false);
        axiumButton.GetComponent<HoveringText>().hoverText.SetActive(false);
        Camera.main.transform.position = new Vector3(515f, 267f, -435f);
        Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
    }

    public void BackButtonInAxium(){
        backButtonFromAxium.SetActive(false); 
        axiumUIPanel.SetActive(false); 
        diagnosisButton.SetActive(true);
        medicineButton.SetActive(HandleMedShown());
        axiumButton.SetActive(true);
        Camera.main.transform.position = new Vector3(0f, 3f, -11f);
        Camera.main.transform.rotation = Quaternion.Euler(5f, 0f, 0f); 
    }

    public void OnClickGoBackDiaAndMed(){
        medicineAns.SetActive(false);
        diagnosisAns.SetActive(false);
        backButtonFromDiaAndMed.SetActive(false);
        diagnosisButton.SetActive(true);
        npcHoverDetector.SetActive(true);
        medicineButton.SetActive(HandleMedShown());

        //Outputs the final grad screen
        if(isDiaCorrect == true && isMedCorrect == true){
            CalculationOfDiaAndMed();
        }

    }

    public void OnClickOfDiagnosis(){
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        diagnosisAns.SetActive(true);
        backButtonFromDiaAndMed.SetActive(true);
        npcHoverDetector.SetActive(false);
    }

    public void OnClickOfMedicine(){
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        medicineAns.SetActive(true);
        backButtonFromDiaAndMed.SetActive(true);
        npcHoverDetector.SetActive(false);
    }


    public bool HandleMedShown(){
        if(isDiaCorrect == false){
            return false;
        }
        else{
            return true;
        }
    }
}
