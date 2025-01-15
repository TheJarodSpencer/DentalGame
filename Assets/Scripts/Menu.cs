using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton(){
        SceneManager.LoadScene("LevelSelector");
    }
    public void OnSettingsButton(){
        SceneManager.LoadScene("SettingsScene");
    }
    
    public void OnCharacterButton(){
        SceneManager.LoadScene("CharacterCreator");
    }
}