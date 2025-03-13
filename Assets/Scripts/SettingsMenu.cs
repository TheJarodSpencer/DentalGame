using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void OnPlayButton(){
        SceneManager.LoadScene("LevelSelectorMainFloor");
    }
    public void OnReturnToStartButton(){
        SceneManager.LoadScene("WelcomeScene");
    }
}
