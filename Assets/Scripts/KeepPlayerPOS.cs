using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepPlayerPOS : MonoBehaviour
{
    public static KeepPlayerPOS Instance;
    public Vector3 playerPosition;
    public string levelSelectorScene;
    public GameObject characterKeepPOS;
    
    //Keep the pos alive
    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }

    public string GetLastSceneName()
    {
        return levelSelectorScene;
    }

    //Get Player info before switch scenes
    public void SetPlayerPosition(GameObject player)
    {
        playerPosition = player.transform.position;
        characterKeepPOS = player;
        levelSelectorScene = SceneManager.GetActiveScene().name;
        Debug.Log("Player position set to: " + playerPosition);
    }

    //Set Player info after scene changes
    public void SetPlayerPositionToStored(GameObject player)
    { 
        if (player != null)
        {
            player.transform.position = playerPosition;
            Debug.Log("Player Position Set To: " + player.transform.position);
        }
        else
        {
            Debug.LogError("Target GameObject is null!");
        }
    }

}
