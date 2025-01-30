using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonManager : MonoBehaviour
{
    public GameObject axiumUIPanel;
    public GameObject diagnosisButton;
    public GameObject medicineButton;
    public GameObject backButtonFromAxium;
    public GameObject axiumButton;

    public void OnClickOfAxium(){
        axiumUIPanel.SetActive(true);
        backButtonFromAxium.SetActive(true); 
        diagnosisButton.SetActive(false);
        medicineButton.SetActive(false);
        axiumButton.SetActive(false);
        Camera.main.transform.position = new Vector3(985f, 650f, -400f);
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

    public void OnClickOfDiagnosis(){

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
