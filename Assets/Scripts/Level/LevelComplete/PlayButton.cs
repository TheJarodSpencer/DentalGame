//This script is used for button clicks in the Levels. 
//When the player clicks "Next" when presented the UI final score this grabs the Player POS before they entered the level for the user to be right 
//back where they left off in level selector.
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

    //Handles the players POS before entered the Level to place them where they were in level selector
    public void OnNextButton()
    {
        Debug.Log("In On Next Button");
        //Load the scene
        string sceneToLoad = KeepPlayerPOS.Instance.GetLastSceneName();//Grabs the scenes last POS
        SceneManager.LoadScene(sceneToLoad);

        //When scene loads move the Player pos
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            GameObject player = GameObject.Find("MCharacter");//Used MCharacter to not mess up the Character within the Levels, so use MCharacter in the LevelSelectors
            if (player != null)
                {
                    KeepPlayerPOS.Instance.SetPlayerPositionToStored(player);
                }
        };
    }

}

