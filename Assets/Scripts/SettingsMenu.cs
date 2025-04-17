using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class SettingsMenu : MonoBehaviour
{
    public GameObject HelpPanel;
    public void OnPlayButton(){
        SceneManager.LoadScene("LevelSelectorMainFloor");
    }
    public void OnReturnToStartButton(){
        SceneManager.LoadScene("WelcomeScene");
    }
    public void OnHelpButton(){
        HelpPanel.SetActive(true);
    }
    public void OnLeaderboardButton(){
        SceneManager.LoadScene("Leaderboard");
    }
    public void OnHelpBackButton(){
        HelpPanel.SetActive(false);
    }
    public void OnExitButton(){
        SceneManager.LoadScene("Login");
    }
}
