using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AllowPaste : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "AdminPanel") 
        {
            Application.ExternalCall("showTextInput");
        }
        else
        {
            Application.ExternalCall("hideTextInput");
        }
    }

    public void ReceiveTextFromHTML(string text)
    {
        if (inputField != null)
        {
            inputField.text = text;
        }
        Debug.Log("Received text from HTML: " + text);
    }
}
