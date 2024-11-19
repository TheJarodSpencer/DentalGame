using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;


public class FireBase : MonoBehaviour
{
    [System.Serializable] //Fix this to make the serializable
    public struct PlayerData
    {
        public string playerName;
        public int playerLevel;
        public float playerExperience;
        public int playerCustomization;
    }

    public int GetCharacterID(){
        GlobalVariables gs = new GlobalVariables();
        int characterID = gs.getCharacterID();
        return characterID;
    }

    public string GetPlayerName(){
        UserAuth user = new UserAuth();
        if(user != null){
            return user.GetUserName();
        }
        Debug.LogError("User instance not found!");
        return "None";
    }

    //Start is called before the first frame update
    void Start()
    {
        PlayerData playerData = new PlayerData
        {
            //Hard coded info
            playerName = GetPlayerName(),
            playerLevel = 10,
            playerExperience = 10.2f, // Make sure this is a float value
            playerCustomization = GetCharacterID()
        };

        string jsonData = JsonUtility.ToJson(playerData);
        SetCharacterDocument("players", "player1", jsonData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCharacterDocument(string collectionPath, string documentId, string jsonData)
    {
        Debug.Log("Im in this character function");
        FirebaseFirestore.SetDocument(collectionPath, documentId, jsonData, gameObject.name, "DisplayData", "DisplayErrorObject");
    }
}




