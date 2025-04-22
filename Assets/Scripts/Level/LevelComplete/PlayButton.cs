using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnPlayButton(){
        //KeepPlayerName kpn = GetComponent<KeepPlayerName>();
        //GlobalVariables GV = GameObject.FindAnyObjectByType<GlobalVariables>();
        //KeepPlayerName.Instance.SetVolume(GV.getAudioVolume());
        SceneManager.LoadScene("WelcomeScene");
    }

    public void OnNextButton()
    {
        Debug.Log("In On Next Button");
        //Load the scene
        string sceneToLoad = KeepPlayerPOS.Instance.GetLastSceneName();
        SceneManager.LoadScene(sceneToLoad);

        //When scene loads move the Player pos
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            GameObject player = GameObject.Find("MCharacter");
            if (player != null)
                {
                    KeepPlayerPOS.Instance.SetPlayerPositionToStored(player);
                }
        };
    }

}

