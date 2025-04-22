using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnPauseButton(){
        Debug.Log("Pause Button Clicked");
        SceneManager.LoadScene("SettingsScene");
    }
}
