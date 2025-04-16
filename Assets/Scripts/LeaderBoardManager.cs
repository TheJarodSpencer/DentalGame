using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; // For OrderByDescending
using TMPro;
using SimpleJSON;
using UnityEngine.SceneManagement;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;
using Unity.VisualScripting;

[System.Serializable]
public class WrapperList
{
    public List<FireBase.PlayerData> players;
}

public class LeaderBoardManager : MonoBehaviour
{
    public TextMeshProUGUI levelsColumnText;     // Left column - Levels
    public TextMeshProUGUI scoresColumnText;     // Right column - Scores
    public TextMeshProUGUI errorText;            // For errors

    void Start()
    {
        GetTop10Players();
    }

    public void GetTop10Players()
    {
        Debug.Log("In top10 players");
        string collectionPath = "players";

        FirebaseFirestore.GetDocumentsInCollection(collectionPath, "LeaderBoardManager", "DisplayData", "DisplayErrorObject");
        Debug.Log("ProcessedCollection");
    }

    public void DisplayData(string data)
{
    if (!string.IsNullOrEmpty(data) && data != "null")
    {
        Debug.Log("Raw Data: " + data);

        // Parse the data using SimpleJSON
        var jsonData = JSON.Parse(data);

        // Check if the JSON data is valid
        if (jsonData != null && jsonData.IsObject)
        {
            var players = new List<FireBase.PlayerData>();
            int count = 0;

            // Loop through the JSON data and create PlayerData objects
            foreach (var key in jsonData.Keys)
            {
                if (count == 10) {
                    break;
                }
                // Access each player node
                var playerNode = jsonData[key].AsObject;

                // Get the playerName
                string playerName = playerNode["playerName"];

                // Get the playerExperience array and convert to float[]
                var experienceArray = playerNode["playerExperience"].AsArray;
                float[] playerExperience = new float[experienceArray.Count];

                for (int i = 0; i < experienceArray.Count; i++)
                {
                    playerExperience[i] = experienceArray[i].AsFloat;  // Convert each element to a float
                }

                // Get the playerCustomization (assumed to be an int)
                int playerCustomization = playerNode["playerCustomization"].AsInt;

                // Create and add PlayerData to the list
                var playerData = new FireBase.PlayerData
                {
                    playerName = playerName,
                    playerExperience = playerExperience,
                    playerCustomization = playerCustomization
                };

                players.Add(playerData);
                count++;
            }

            Debug.Log($"Total Players Found: {players.Count}");

            // Optionally display player information for debugging purposes
            foreach (var player in players)
            {
                Debug.Log($"Player: {player.playerName} | XP: {string.Join(",", player.playerExperience)} | Customization: {player.playerCustomization}");
            }

            // Now you can process and display the data, for example:
            DisplayTopPlayers(players);
        }
        else
        {
            Debug.LogError("No valid data found in the JSON.");
        }
    }
    else
    {
        Debug.LogError("No data received or data is null.");
    }
}

private void DisplayTopPlayers(List<FireBase.PlayerData> players)
{
    // Sort players by best score (assuming you want to show top scores)
    var sortedByScores = players.OrderByDescending(player => player.playerExperience.Max()).ToList();
    
    // Sort players by the highest level completed (assuming you want to show most levels completed)
    var sortedByLevels = players.OrderByDescending(player => player.playerExperience.Length).ToList();

    // Display the top players (you can call your existing method for this)
    DisplayTopPlayersByCategory(sortedByLevels, sortedByScores);
}

    public void DisplayErrorObject(string error)
    {
        errorText.text = error;
        Debug.LogError(error);
    }

    private int GetHighestLevel(FireBase.PlayerData player)
    {
        int total = 0;
        if(player.playerExperience != null) {
            for (int i = 0; i < player.playerExperience.Length; i++) {
                if(player.playerExperience[i] > 0f) {
                    total++;
                }
            }
            return total;
        } 
        else {
            return 0;
        }
    }

    private float GetBestScore(FireBase.PlayerData player)
    {
        return player.playerExperience != null && player.playerExperience.Length > 0
            ? player.playerExperience.Max()
            : 0f;
    }

    private void DisplayTopPlayersByCategory(List<FireBase.PlayerData> byLevels, List<FireBase.PlayerData> byScores)
    {
        levelsColumnText.text = "Most Levels Completed\n";
        scoresColumnText.text = "Highest Scores\n";

        for (int i = 0; i < Mathf.Max(byLevels.Count, byScores.Count); i++)
        {
            if (i < byLevels.Count)
            {
                var p = byLevels[i];
                levelsColumnText.text += $"{i + 1}. {p.playerName} - {GetHighestLevel(p)} Levels\n";
            }

            if (i < byScores.Count)
            {
                var p = byScores[i];
                scoresColumnText.text += $"{i + 1}. {p.playerName} - Score: {GetBestScore(p)}\n";
            }
        }
    }

    public void DisplayError(string error)
    {
        errorText.text = error;
        Debug.LogError(error);
    }

    public void BackButton(){
        SceneManager.LoadScene("SettingsScene");
    }
}
