using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;


public class FireBase : MonoBehaviour
{
    public UserAuth user;
    private string characterName;

    [System.Serializable] //Fix this to make the serializable
    public struct PlayerData
    {
        public string playerName;
        public int playerLevel;
        public float playerExperience;
        public int playerCustomization;
    }

    public int GetCharacterID()
    {
        GlobalVariables gs = FindObjectOfType<GlobalVariables>();
        if (gs != null)
        {
            return gs.getCharacterID();
        }
        Debug.LogError("GlobalVariables instance not found!");
        return 0; 
    }


    public void SetPlayerName(string username){
        characterName = username;//Gets character name
        Debug.Log("Character Name: " + username);
        UpdateCharacterField("playerName", characterName);
    }

    public string GetPlayerName(){
        return characterName;
    }

    //Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameObject name: " + gameObject.name);




        PlayerData playerData = new PlayerData
        {
            //THESE WILL LATER GRAB FROM THE DATABASE TO HAVE UPDATED INFORMATION(NICOLE)
            playerName = "Bob", 
            playerLevel = 10, 
            playerExperience = 10.2f, // Make sure this is a float value
            playerCustomization = GetCharacterID()
        };

        string jsonData = JsonUtility.ToJson(playerData);
        SetCharacterDocument("players", GetPlayerName(), jsonData);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private PlayerData GetPlayerData()
    {
    // Fetch the current data from Firebase or wherever it’s stored
        return new PlayerData
        {
        playerName = GetPlayerName(),  // Example, replace with actual data
        playerLevel = 10,
        playerExperience = 10.0f,
        playerCustomization = 1
        };
    }   


    //To access the character customization update of player!
    public void UpdateCharacterField(string fieldName, object value)
    {
        PlayerData playerData = GetPlayerData();

        switch(fieldName)
        {
            case "playerName":
                playerData.playerName = (string)value;
                break;
            case "playerLevel":
                playerData.playerLevel = (int)value;
                break;
            case "playerExperience":
                playerData.playerExperience = (float)value;
                break;
            case "playerCustomization":
                playerData.playerCustomization = (int)value;
                break;
        }

        string jsonUpdate = JsonUtility.ToJson(playerData);
        Debug.Log("Json Update: " + jsonUpdate);
        FirebaseFirestore.UpdateDocument("players", "DentalSection1", jsonUpdate, "Character", "DisplayData", "DisplayErrorObject");//Updates the character info
    }

    public void SetCharacterDocument(string collectionPath, string documentId, string jsonData)
    {
        Debug.Log("Im in this character function");
        FirebaseFirestore.SetDocument(collectionPath, documentId, jsonData, "Character", "DisplayData", "DisplayErrorObject");
    }

    public void DisplayData(string data)
    {
        //Handle display data
        Debug.Log("Received data: " + data);
    }
    public void DisplayErrorObject(string error)
    {
        Debug.LogError("Error occurred: " + error);
    }
}




