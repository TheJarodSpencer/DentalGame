using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;

public class FileUploadHandler : MonoBehaviour
{
    [System.Serializable]
    public class UsernamesList
    {
        public List<string> usernames;
    }

    [System.Serializable]
    public class UserData
    {
        public string username;
        public string password;
    }
    
    public void OpenFileUploaded(string jsonData)
    {
        Debug.Log("File content recieved: " + jsonData);

        List<string> usernames = JsonUtility.FromJson<UsernamesList>(jsonData).usernames;

        foreach(string player in usernames)
        {
            CreateUser(player);
        }
        
    }

    private void CreateUser(string username)
    {
        string documentID = username.Split('@')[0];
        UserData newUser = new UserData
        {
          username = username,
          password = "test123"  
        };

        string jsonData = JsonUtility.ToJson(newUser);
        FirebaseFirestore.SetDocument("users", documentID, jsonData, "Character", "DisplayData", "DisplayErrorObject");
    }

}
