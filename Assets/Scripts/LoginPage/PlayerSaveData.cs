//This script is called in login and grabs the player data from firebase to get character custizimation and experience right when loading into the game.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : MonoBehaviour
{
    public static PlayerSaveData Instance;
    public FireBase.PlayerData currentSaveData;
    
    //Keeps the player save data alive
    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    //Sets the FireBase data to current save data (This is used in Firebase script)
    public void SetPlayerData(FireBase.PlayerData data){
        currentSaveData  = data;
    }

    //Gets the player data (can easily be called across scripts using Instance)
    public FireBase.PlayerData GetPlayerData(){
        return currentSaveData;
    }

    //Gets the player customization number stored in currentSaveData
    public int GetPlayerCustomization(){
        return currentSaveData.playerCustomization;
    }

    //Gets the player exp array stored in currentSaveData
    public float[] GetPlayerExperience(){
        return currentSaveData.playerExperience;
    }
}
