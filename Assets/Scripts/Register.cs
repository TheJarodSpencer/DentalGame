using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;//to use streamwriter
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public TMP_InputField registerUsername;
    public TMP_InputField registerPassword;
    public Button registerButton;

    private string filePath;
 
    public void GoBack()
    {
        SceneManager.LoadScene("Login");
    }

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/user_data.txt";    
    }

    public void OnRegisterButtonClick()
    {
        string username = registerUsername.text;
        string password = registerPassword.text;

        if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)){
            Debug.Log("Username or password is empty");
            return;
        }
        SaveUserData(username, password);
    }

    public void SaveUserData(string username, string password)
    {
        using(StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{username}:{password}");
        }
        Debug.Log("User data saved to " + filePath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
