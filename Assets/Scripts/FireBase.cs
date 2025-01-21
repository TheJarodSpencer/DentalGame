using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;


public class FireBase : MonoBehaviour
{
    public static List<string> registeredPlayerNames = new List<string>();
    public UserAuth user;
    public string characterName;
    public PlayerData currentPlayerData;
    //public bool ForGetDocumentInfo = false;

    [System.Serializable] //Fix this to make the serializable
    public struct PlayerData
    {
        public string playerName;
        public int playerLevel;
        public float playerExperience;
        public int playerCustomization;
    }

    public void SetPlayerName(string username)
    {
        characterName = username;
        Debug.Log("In setplayername Username"+ username);
        if (registeredPlayerNames.Contains(username))
        {
            Debug.Log("Character exsists" + username);
        }
        else
        {
            registeredPlayerNames.Add(username);
            Debug.Log("Username does not exist in the list.");
            Debug.Log("Character List Now");
            foreach (string playerName in registeredPlayerNames)
            {
                Debug.Log(playerName);
            }

            PlayerData newPlayerData = new PlayerData
            {
                playerName = username,
                playerLevel = 2,            // Default level
                playerExperience = 2.0f,    // Default experience
                playerCustomization = 2     // Default customization
            };

            // Convert PlayerData to JSON and store it
            string jsonData = JsonUtility.ToJson(newPlayerData);
            Debug.Log("Raw Data in Create Character: " + jsonData);
            SetCharacterDocument("players", username, jsonData);
        }
    }

    //Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameObject name: " + gameObject.name);
        Debug.Log("Character name: " + KeepPlayerName.Instance.GetCharacterName());
        GetPlayerData(KeepPlayerName.Instance.GetCharacterName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPlayerData(string character)
    {
        Debug.Log("I am in the GetPlayerData function" + character);
        //Debug.Log("Num1" + ForGetDocumentInfo);
        //ForGetDocumentInfo = true;
        //Debug.Log("Num2" + ForGetDocumentInfo);
        FirebaseFirestore.GetDocument("players", character, "Character", "DisplayData", "DisplayErrorObject");
    }

    public void HandlePlayerData(PlayerData playerData)
    {
        Debug.Log("Name: " + playerData.playerName);
        Debug.Log("Player Level: " + playerData.playerLevel);
        Debug.Log("Player Exp: " + playerData.playerExperience);
        PlayerSaveData.Instance.SetPlayerData(playerData);
        //isPlayerDataHandled = true;
    }

    public void UpdateCharacterField(string fieldName, object value)
    {
        PlayerData currentPlayerData = PlayerSaveData.Instance.GetPlayerData();
        Debug.Log("Name: " + currentPlayerData.playerName);
        Debug.Log("Player Level: " + currentPlayerData.playerLevel);
        Debug.Log("Player Exp: " + currentPlayerData.playerExperience);
        
        // Now proceed with updating the data
        Debug.Log("Now updating character info");
        switch (fieldName)
        {
            case "playerName":
                currentPlayerData.playerName = (string)value;
                break;
            case "playerLevel":
                currentPlayerData.playerLevel = (int)value;
                break;
            case "playerExperience":
                currentPlayerData.playerExperience = (float)value;
                break;
            case "playerCustomization":
                currentPlayerData.playerCustomization = (int)value;
                break;
        }

        //Convert the updated data to JSON and send to Firebase
        string jsonUpdate = JsonUtility.ToJson(currentPlayerData);
        Debug.Log("Json Update: " + jsonUpdate);
        FirebaseFirestore.UpdateDocument("players", characterName, jsonUpdate, "Character", "DisplayData", "DisplayErrorObject");

        //Reset the flag for next data update
        //isPlayerDataHandled = false;
    }

    public void SetCharacterDocument(string collectionPath, string documentId, string jsonData)
    {
        Debug.Log("Im in this character function");
        FirebaseFirestore.SetDocument(collectionPath, documentId, jsonData, "Character", "DisplayData", "DisplayErrorObject");
    }

    public void DisplayData(string data)
    {
        if (!string.IsNullOrEmpty(data) && data != "null")
        {
            Debug.Log("Raw Data: " + data);

            PlayerData playerData = JsonUtility.FromJson<PlayerData>(data);
            HandlePlayerData(playerData);
            Debug.Log("Player Data Retrieved: " + data);
            //ForGetDocumentInfo = false;
        }
        else{
            Debug.LogError("No data received or data is null.");
        }
    }

    public void DisplayErrorObject(string error)
    {
        Debug.LogError("Error occurred: " + error);
    }
}




