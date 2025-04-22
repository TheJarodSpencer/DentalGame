using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;

public class SetPlayerInfo : MonoBehaviour
{
    public FireBase fireBase;

    public void CheckExsistingPlayerInfo()
    {
        Debug.Log("In CheckExsistingPlayerInfo()");
        FirebaseFirestore.GetDocument("players", KeepPlayerName.Instance.GetCharacterName(), "Character", "DisplayData", "DisplayErrorObject");
    }

    public void DisplayData(string data)
    {
        FireBase.PlayerData checkPlayerData = JsonUtility.FromJson<FireBase.PlayerData>(data);
        if(checkPlayerData.playerName == KeepPlayerName.Instance.GetCharacterName()){
            TheCharacterExsits();
        }
        else{
            TheCharacterDoesNotExsist();
        }
    }

    public void DisplayErrorObject(string error)
    {
        Debug.LogError("Error occurred: " + error);
    }

    public void TheCharacterExsits(){
        Debug.Log("Character exsists: " + KeepPlayerName.Instance.GetCharacterName());
    }

    public void TheCharacterDoesNotExsist()
    {
        float[] newLevelExperience = new float[20];

        for (int i = 0; i < newLevelExperience.Length; i++)
        {
            newLevelExperience[i] = 0.0f;
        }

        FireBase.PlayerData newPlayerData = new FireBase.PlayerData
            {
                playerName = KeepPlayerName.Instance.GetCharacterName(),
                playerExperience = newLevelExperience,
                playerCustomization = 1110200     //Default customization
            };

            //Convert PlayerData to JSON and store it
            string jsonData = JsonUtility.ToJson(newPlayerData);
            Debug.Log("Raw Data in Create Character: " + jsonData);
            fireBase.SetCharacterDocument("players", KeepPlayerName.Instance.GetCharacterName(), jsonData);
    }



}

