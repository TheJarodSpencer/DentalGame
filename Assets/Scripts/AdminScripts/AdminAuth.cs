using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for textmeshpro
using UnityEngine.SceneManagement;//to go to next scene
using UnityEngine.UI;
using System.IO;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;

public class AdminAuth : MonoBehaviour
{
    public struct Admin
    {
        public string username;
        public string password;
    }

    [SerializeField]//show in editor but not editable
    private TMP_InputField usernameInput;
    [SerializeField]
    private TMP_InputField passwordInput;
    [SerializeField]
    private TextMeshProUGUI errorText;
    public Button GoBackButton;

    private string username;
    private string password;
    private string putIn;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer)
            DisplayError("The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");
    }

    public void SubmitAccess()
    {
        username = usernameInput.text;
        password = passwordInput.text;

        //Begin Check here
        Debug.Log("USERNAME: " + username);//output to check if the input correct
        Debug.Log("PASSWORD: " + password);
        string loginCheckMessage = CheckLoginInfo(username, password);

        if (!string.IsNullOrEmpty(loginCheckMessage)){
            Debug.LogError("ERROR: " + loginCheckMessage);
            errorText.text = ("ERROR: " + loginCheckMessage);
        }
        else {
            putIn = username.Split("@")[0];
            Debug.Log("Gameobject name" + gameObject.name);
            FirebaseFirestore.GetDocument("admins", putIn, "AdminManager", "DisplayData", "DisplayErrorObject");//Pulls from Database
        }
    }

    public void DisplayData(string data)
    {
        Debug.Log(data);
        Debug.Log(data.Length);
        if(data == "null") {
            errorText.text = "Incorrect Username or Password";
            return;
        }
        Admin temp = JsonUtility.FromJson<Admin>(data);//Built in to make a file to json file
        if(temp.username == username && temp.password == password) {
            SceneManager.LoadScene("AdminPanel");
        }
        else {
            errorText.text = "Incorrect Username or Password";
        }
    }

    public void DisplayError(string error)
    {
        errorText.text = error;
        Debug.LogError(error);
    }

    private string CheckLoginInfo(string username, string password)
    {
        if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
        {
            return "Both username and password are empty";
        }
        if (string.IsNullOrEmpty(username))
        {
            return "Username was empty";
        }
        if (string.IsNullOrEmpty(password))
        {
            return "Password was empty";
        }
        else{
            for(int i = 0; i < username.Length; i++) {
                if(username[i] == '@'){
                    return "";
                }
            }
            return "Username must be an email";
        }  
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Login");
    }
}
