using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : MonoBehaviour
{
    public static PlayerSaveData Instance;
    public FireBase.PlayerData currentSaveData;
    
    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void SetPlayerData(FireBase.PlayerData data){
        currentSaveData  = data;
    }

    public FireBase.PlayerData GetPlayerData(){
        return currentSaveData;
    }

    public int GetPlayerCustomization(){
        return currentSaveData.playerCustomization;
    }

    public float[] GetPlayerExperience(){
        return currentSaveData.playerExperience;
    }
}
