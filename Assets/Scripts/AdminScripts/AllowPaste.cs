//This script is connected to the INDEX.html that is produced when you build the game. The updated index we have implments javascript which we used for admins to copy
//and paste users from a .txt to the game. By pressing "V" after putting information in this textbox it will pull it and paste it in the game on itch. This script handles
//those javascript calls in the index.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AllowPaste : MonoBehaviour
{
    public TMP_InputField inputField;//Text field the JS textbox is linked to

    void Start()
    {
        //If the current scne is not the admin panel it will not display the text box untill on the AdminPanel scene
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

    //Store the text recieved from the html onto the Unity textbox that you dragged in the inspector
    public void ReceiveTextFromHTML(string text)
    {
        if (inputField != null)
        {
            inputField.text = text;
        }
       // Debug.Log("Received text from HTML: " + text);
    }
}
