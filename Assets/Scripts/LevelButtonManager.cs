using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour
{
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

    void Start(){
        LoadTextFromFile(diaFile, diaButtons);
        LoadTextFromFile(medFile, medButtons);
    }

    void LoadTextFromFile(TextAsset textFile, Button[] buttons){
        string[] lines = textFile.text.Split('\n');

        for(int i = 0; i < buttons.Length && i < lines.Length; i++){
            TMP_Text buttonText = buttons[i].GetComponentInChildren<TMP_Text>();
                if (buttonText != null)
                {
                    buttonText.text = lines[i].Trim(); // Set button text from file
                }
        }
    }

    public void OnClickOfAxium(){
        axiumUIPanel.SetActive(true);
        backButtonFromAxium.SetActive(true); 
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        axiumButton.SetActive(false);
        Camera.main.transform.position = new Vector3(515f, 267f, -425f);
        Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
    }

    public void BackButtonInAxium(){
        backButtonFromAxium.SetActive(false); 
        axiumUIPanel.SetActive(false); 
        diagnosisButton.SetActive(true);
        medicineButton.SetActive(true);
        axiumButton.SetActive(true);
        Camera.main.transform.position = new Vector3(0f, 3f, -11f);
        Camera.main.transform.rotation = Quaternion.Euler(5f, 0f, 0f); 
    }

    public void OnClickGoBackDiaAndMed(){
        medicineAns.SetActive(false);
        diagnosisAns.SetActive(false);
        backButtonFromDiaAndMed.SetActive(false);
        diagnosisButton.SetActive(true);
        medicineButton.SetActive(true);

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
}
