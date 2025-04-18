using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for textmeshpro
using UnityEngine.SceneManagement;//to go to next scene
using UnityEngine.UI;
using System.IO;//to use streamwriter


using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;

public class UserAuth : MonoBehaviour
{
    public GameObject LoginManagerPulled;//Added to always find!
    private string loginManagerName;

    public struct User
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

    public SetPlayerInfo setInfo;
    private string putIn;

    public string username;
    private string password;

    // Start is called before the first frame update
    void Start()
    {
        loginManagerName = LoginManagerPulled.name;
         if (Application.platform != RuntimePlatform.WebGLPlayer)
                //SceneManager.LoadScene("WelcomeScene");
                DisplayError("The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");

    }
    //Executes when button pressed. Will grab username and password and check correct :)

    public string GetUserName(){
        return username;
    }

    public void SetUserName(string newUsername){
        username = newUsername;
        KeepPlayerName.Instance.SetCharacterName(username);//Sets GameObject in Login Mangaer Name to the stored name and does not delete
    }

    public void SubmitLogin()
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
            FirebaseFirestore.GetDocument("users", putIn, loginManagerName, "DisplayData", "DisplayErrorObject");//Pulls from Database
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
        User temp = JsonUtility.FromJson<User>(data);//Built in to make a file to json file
        if(temp.username == username && temp.password == password && temp.username != "admin@siue.edu") {
            SetUserName(username);//SETTING THE USERNAME FOR THE DATABASE(Nicole)
            setInfo.CheckExsistingPlayerInfo();//SETTING THE PLAYER NAME IN THE DATABASE
            if(temp.password == "test123"){
                SceneManager.LoadScene("ChangePassword");
            }
            else{
                SceneManager.LoadScene("WelcomeScene");
            }
        }
        else if(temp.username == "admin@siue.edu" && temp.password == password){
            SceneManager.LoadScene("AdminLogin");
        }
        else {
            errorText.text = "Incorrect Username or Password";
        }
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

    //Return empty string, otherwise return string with error :)
    //Checks that info correct
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
}