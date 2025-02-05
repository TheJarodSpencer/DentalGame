using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour
{
    public GlobalVariables GV;

    public GameObject axiumUIPanel;
    public GameObject diagnosisButton;
    public GameObject medicineButton;
    public GameObject backButtonFromAxium;
    public GameObject axiumButton;
    public GameObject diagnosisAns;
    public GameObject medicineAns;
    public GameObject backButtonFromDiaAndMed;

    //For the Diagnosis and Medicine Anwsers
    public Button[] medButtons;
    public Button[] diaButtons;
    public TextAsset diaFile; 
    public TextAsset medFile;

    //For if wrong or right button for Med and Diagnosis
    public int correctDiaAnswerIndex;
    public int correctMedAnswerIndex;
    public bool isDiaCorrect =  false;
    public int correctAnswers = 0;


    void Start(){
        LoadTextFromFile(diaFile, diaButtons);
        string[] diaLines = diaFile.text.Split('\n');
        correctDiaAnswerIndex = int.Parse(diaLines[0].Trim());
        LoadTextFromFile(medFile, medButtons);
        string[] medLines = medFile.text.Split('\n');
        correctMedAnswerIndex = int.Parse(medLines[0].Trim());

        foreach (Button button in diaButtons)
        {
            button.onClick.AddListener(() => OnClickColorsTheButtons(button, diaButtons, correctDiaAnswerIndex));
        }
        
        foreach (Button button in medButtons)
        {
            button.onClick.AddListener(() => OnClickColorsTheButtons(button, medButtons, correctMedAnswerIndex));
        }
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

    public void OnClickColorsTheButtons(Button clickedButton, Button[] buttons, int correctAnswerIndex){
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);
        if (buttonIndex == correctAnswerIndex)
        {
            clickedButton.GetComponent<Image>().color = Color.green; //Correct
            isDiaCorrect = true;
            ++correctAnswers;
            if(correctAnswers == 2){
                SceneManager.LoadScene("LevelSelector");
            }
            Debug.Log("Correct answer!");
        }
        else
        {
            clickedButton.GetComponent<Image>().color = Color.red; //Wrong
            Debug.Log("Wrong answer!");
        }
    }

    public void OnClickOfAxium(){
        axiumUIPanel.SetActive(true);
        backButtonFromAxium.SetActive(true); 
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        axiumButton.SetActive(false);
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
        medicineButton.SetActive(HandleMedShown());

    }

    public void OnClickOfDiagnosis(){
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        diagnosisAns.SetActive(true);
        backButtonFromDiaAndMed.SetActive(true);
    }

    public void OnClickOfMedicine(){
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        medicineAns.SetActive(true);
        backButtonFromDiaAndMed.SetActive(true);
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
