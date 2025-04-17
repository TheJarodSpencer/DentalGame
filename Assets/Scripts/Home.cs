using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedHome() {
        temp.SetActive(true);
    }

    public void ClickedCancel() {
        temp.SetActive(false);
    }

    public void ClickedContinue() {
        SceneManager.LoadScene("WelcomeScene");
    }
}
