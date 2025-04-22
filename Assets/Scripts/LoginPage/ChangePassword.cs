using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;

public class ChangePassword : MonoBehaviour
{
    public TMP_InputField passwordField;
    public TMP_InputField confirmPasswordField;
    public TextMeshProUGUI feedbackText;

    public void UpdatePassword()
    {
        string newPassword = passwordField.text.Trim();
        string confirmPassword = confirmPasswordField.text.Trim();

        if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
        {
            ShowFeedback("Password fields cannot be empty.", Color.red);
            return;
        }

        if (newPassword != confirmPassword)
        {
            ShowFeedback("Passwords do not match.", Color.red);
            return;
        }

        if (newPassword == "test123")
        {
            ShowFeedback("Please make a new password", Color.red);
            return;
        }

        string userEmail = KeepPlayerName.Instance.GetCharacterName();
        string username = userEmail.Split('@')[0];

        AdminPanel.UserData updatedUser = new AdminPanel.UserData(userEmail, newPassword);
        string jsonData = JsonUtility.ToJson(updatedUser);

        FirebaseFirestore.UpdateDocument("users", username , jsonData, gameObject.name, "DisplayData", "DisplayErrorObject");

        ShowFeedback("Updating password", Color.yellow);
    }

    public void DisplayData(string result)
    {
        ShowFeedback("Password updated successfully! Please make sure to store your new password in a safe place. If you forget it, you will need to contact your professors to request a password reset.", Color.green);
        Debug.Log("Password updated: " + result);
        gameObject.SetActive(false);
    }

    public void DisplayErrorObject(string error)
    {
        var parsedError = StringSerializationAPI.Deserialize(typeof(FirebaseError), error) as FirebaseError;
        ShowFeedback("Error: " + parsedError.message, Color.red);
        Debug.LogError(parsedError.message);
    }

    private void ShowFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
    }

    public void BackButton(){
        SceneManager.LoadScene("Login");
    }
}
