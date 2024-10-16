using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for textmeshpro
using UnityEngine.SceneManagement;//to go to next scene
using UnityEngine.UI;
using System.IO;//to use streamwriter

public class LoginManager : MonoBehaviour
{
    [SerializeField]//show in editor but not editable
    private TMP_InputField usernameInput;
    [SerializeField]
    private TMP_InputField passwordInput;
    [SerializeField]
    private TextMeshProUGUI errorText;

    private string filePath;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/user_data.txt";//opens file path
    }

    //Executes when button pressed. Will grab username and password and check correct :)
    public void SubmitLogin()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        //Begin Check here
        Debug.Log("USERNAME: " + username);//output to check if the input correct
        Debug.Log("PASSWORD: " + password);
        string loginCheckMessage = CheckLoginInfo(username, password);

        //verify info field is not blank
        if(string.IsNullOrEmpty(loginCheckMessage)){
            Debug.Log("LOGIN");
            SceneManager.LoadScene("FirstScene");
        }
        else{
            Debug.LogError("ERROR: " + loginCheckMessage);
            errorText.text = ("ERROR: " + loginCheckMessage);
        }
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
        if (ValidateUser(username, password) == true)
        {
            Debug.Log("Login Successful");
            return "";
        }
        else
        {
            return "Incorrect username or password";
        }
    }

    public bool ValidateUser(string username, string password)
    {
        if (!File.Exists(filePath))
        {
            Debug.Log("User data file does not exist");
            return false;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string storedUsername = parts[0].Trim();
                    string storedPassword = parts[1].Trim();
                    if (storedUsername == username && storedPassword == password)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    //When user types in input field the error message goes away
    public void RemoveErrorText()
    {
        errorText.text = "";
    }

    public void SignUp()
    {
        SceneManager.LoadScene("RegisterUser");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
