using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;

public class AdminResetPassword : MonoBehaviour
{
    public TMP_InputField emailField;
    public TextMeshProUGUI feedbackText;

    private const string DefaultPassword = "test123";

    public void ResetUserPassword()
    {
        string email = emailField.text.Trim();

        if (string.IsNullOrEmpty(email))
        {
            ShowFeedback("Email field cannot be empty.", Color.red);
            return;
        }

        if (!IsValidSIUEEmail(email))
        {
            ShowFeedback("Invalid email format. Please use @siue.edu email.", Color.red);
            return;
        }

        string username = email.Split('@')[0];
        AdminPanel.UserData resetUser = new AdminPanel.UserData(email, DefaultPassword);
        string jsonData = JsonUtility.ToJson(resetUser);

        FirebaseFirestore.UpdateDocument("users", username, jsonData, gameObject.name, "DisplaySuccess", "DisplayErrorObject");

        ShowFeedback("Resetting password...", Color.yellow);
    }

    public void DisplaySuccess(string result)
    {
        ShowFeedback("Password has been reset to 'test123'.", Color.green);
        Debug.Log("Password reset: " + result);
    }

    public void DisplayErrorObject(string error)
    {
        var parsedError = StringSerializationAPI.Deserialize(typeof(FirebaseError), error) as FirebaseError;
        ShowFeedback("Error: " + parsedError.message, Color.red);
        Debug.LogError(parsedError.message);
    }

    private bool IsValidSIUEEmail(string email)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@siue\.edu$");
    }

    private void ShowFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
    }
}
