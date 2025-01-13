using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void OnPlayButton(){
        SceneManager.LoadScene("FirstScene");
    }
    public void OnReturnToStartButton(){
        SceneManager.LoadScene("WelcomeScene");
    }
}
