using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine.SceneManagement;//Go back to main menu

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;

public class AdminPanel : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_InputField removeField;
    public TextMeshProUGUI outputText; 
    private const string DefaultPassword = "test123";
    private string collectionPath = "users"; 
    private TextMeshProUGUI errorText; 
    public FireBase fireBase;

    [SerializeField]
    public Button SubmittButtonNew;


    [Serializable]
    public struct UserData
    {
        public string username;
        public string password;

        public UserData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }

    void Start()
    {
        //if (Application.platform != RuntimePlatform.WebGLPlayer)
            //DisplayError("The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");
    }

    public void ProcessInput()
    {
        string userInput = inputField.text;
        //Split the input by semicolons into individual users
        string[] users = userInput.Split(';');
        List<UserData> validUsers = new List<UserData>();  //To store valid users

        foreach (string user in users)
        {
            string trimmedUser = user.Trim();  //Trim spaces from the user input
            Debug.Log("User: " + trimmedUser);

            //Validate SIUE email format
            if (!IsValidSIUEEmail(trimmedUser))
            {
                Debug.LogError($"Invalid email: {trimmedUser}. Must be an SIUE email (@siue.edu).");
                continue;  //Skip invalid emails
            }

            string username = trimmedUser.Split('@')[0];
            UserData userData = new UserData(username + "@siue.edu", DefaultPassword); //User data
            validUsers.Add(userData);  
        }

        // Now that all users are validated, write to Firebase
        foreach (UserData userData in validUsers)
        {
            string jsonData = JsonUtility.ToJson(userData);
            Debug.Log($"Valid SIUE User: {userData.username}");
            string username = userData.username.Replace("@siue.edu", "");
            FirebaseFirestore.SetDocument(collectionPath, username, jsonData, gameObject.name, "DisplayData", "DisplayErrorObject");
            PlayerSetUp(username);
        }

        if (validUsers.Count == 0)
        {
            Debug.LogError("No valid SIUE users were found.");
        }
    }

    public void ProcessRemoval(){




    }

    bool IsValidSIUEEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@siue\.edu$";  // Regex to validate SIUE email
        return Regex.IsMatch(email, pattern);
    }

    public void DisplayData(string data)
    {
        outputText.color = outputText.color == Color.green ? Color.blue : Color.green;
        outputText.text = data;
        Debug.Log(data);
    }

    public void DisplayErrorObject(string error)
    {
        var parsedError = StringSerializationAPI.Deserialize(typeof(FirebaseError), error) as FirebaseError;
        DisplayError(parsedError.message);
    }

    public void DisplayError(string error)
    {
        errorText.text = error;
        Debug.LogError(error);
    }

    public void PlayerSetUp(string username)
    {
        FireBase.PlayerData newPlayerData = new FireBase.PlayerData
        {
            playerName = username + "@siue.edu",  // Use the user's username as the character name
            playerLevel = 0,
            playerExperience = 0.0f,
            playerCustomization = 0
        };

        string jsonData = JsonUtility.ToJson(newPlayerData);
        Debug.Log("Raw Data in Create Character: " + jsonData);

        fireBase.SetCharacterDocument("players", username + "@siue.edu", jsonData);
    } 

    public void Return(){
        SceneManager.LoadScene("Login");
    }

}
