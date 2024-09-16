using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for textmeshpro
using UnityEngine.SceneManagement;//to go to next scene

public class LoginManager : MonoBehaviour
{
    [SerializeField]//show in editor but not editable
    private TMP_InputField usernameInput;
    [SerializeField]
    private TMP_InputField passwordInput;
    [SerializeField]
    private TextMeshProUGUI errorText;

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
    //checks that info correct
    private string CheckLoginInfo(string username, string password)
    {
        string returnString = "";
        if(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password)){
            returnString = "Both username and password are empty";
        }
        if(string.IsNullOrEmpty(username)){
            returnString = "Username was empty";
        }
        else if(string.IsNullOrEmpty(password)){
            returnString = "Password was empty";
        }
        else{
            returnString = "";
        }
        Debug.Log("RETURN_STRING: " + returnString);
        return returnString;

    }

    //When user types in input field the error message goes away
    public void RemoveErrorText()
    {
        errorText.text = "";
    }



    //NOT BEING USED 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
