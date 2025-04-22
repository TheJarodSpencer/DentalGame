using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    //NOT USED IN ANY CURRENT SCENES
    // Start is called before the first frame update
    public void OnBackButton(){
        SceneManager.LoadScene("WelcomeScene");
    }
}
