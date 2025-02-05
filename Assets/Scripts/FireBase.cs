using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;


public class FireBase : MonoBehaviour
{
    public PlayerData currentPlayerData;

    [System.Serializable] //Fix this to make the serializable
    public struct PlayerData
    {
        public string playerName;
        public int playerLevel;
        public float playerExperience;
        public int playerCustomization;
    }

    //Start is called before the first frame update
    void Start()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer){
            Debug.Log("The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");
            FireBase tmp = GetComponent<FireBase>();
            tmp.enabled = false;
            return;
        }
        
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
        FirebaseFirestore.GetDocument("players", character, "Character", "DisplayData", "DisplayErrorObject");
    }

    public void HandlePlayerData(PlayerData playerData)
    {
        Debug.Log("Name: " + playerData.playerName);
        Debug.Log("Player Level: " + playerData.playerLevel);
        Debug.Log("Player Exp: " + playerData.playerExperience);
        PlayerSaveData.Instance.SetPlayerData(playerData);//Saves the PlayerData to a Gameobject and does not delete it
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
        FirebaseFirestore.UpdateDocument("players", KeepPlayerName.Instance.GetCharacterName(), jsonUpdate, "Character", "DisplayData", "DisplayErrorObject");

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




