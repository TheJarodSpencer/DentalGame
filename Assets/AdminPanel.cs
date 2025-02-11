using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdminPanel : MonoBehaviour
{
    public InputField inputField;

    void Start()
    {
        // Optionally, add a listener to process input when the user presses Enter
        inputField.onEndEdit.AddListener(ProcessInput);
    }

    void ProcessInput(string userInput)
    {
        // Do something with the input text, for example, split by semicolons
        string[] users = userInput.Split(';');
        foreach (string user in users)
        {
            Debug.Log("User: " + user.Trim());
        }
    }
}
