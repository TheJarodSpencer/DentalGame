//This script is used in the Leadboard scene that displays the most levels completed ranked and best score ranked (1-10)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; //For OrderByDescending
using TMPro;
using SimpleJSON;//To parse multiple data pulls from firebase
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
    public TextMeshProUGUI levelsColumnText;     //Left column - Levels
    public TextMeshProUGUI scoresColumnText;     //Right column - Scores
    public TextMeshProUGUI errorText;            //For errors

    void Start()
    {
        //Called on start and it grabs all the users data in the collection path of players
        GetTop10Players();
    }

    public void GetTop10Players()
    {
        //Debug.Log("In top10 players");
        string collectionPath = "players";
        FirebaseFirestore.GetDocumentsInCollection(collectionPath, "LeaderBoardManager", "DisplayData", "DisplayErrorObject");
        //Debug.Log("ProcessedCollection");
    }

    public void DisplayData(string data)
{
    if (!string.IsNullOrEmpty(data) && data != "null")
    {
        //Debug.Log("Raw Data: " + data);
        //Parse the data using SimpleJSON
        var jsonData = JSON.Parse(data);

        if (jsonData != null && jsonData.IsObject)
        {
            //Store players data
            var players = new List<FireBase.PlayerData>();
            int count = 0;

            //Loop through the JSON data and create PlayerData objects
            foreach (var key in jsonData.Keys)
            {
                if (count == 10) {
                    break;
                }
                //Access each player node
                var playerNode = jsonData[key].AsObject;
                string playerName = playerNode["playerName"]; //In firebase script

                //Get the playerExperience
                var experienceArray = playerNode["playerExperience"].AsArray;
                float[] playerExperience = new float[experienceArray.Count];

                for (int i = 0; i < experienceArray.Count; i++)
                {
                    playerExperience[i] = experienceArray[i].AsFloat;  //Convert exp to a float array
                }
                int playerCustomization = playerNode["playerCustomization"].AsInt;

                //Create and add PlayerData to the list
                var playerData = new FireBase.PlayerData
                {
                    playerName = playerName,
                    playerExperience = playerExperience,
                    playerCustomization = playerCustomization
                };

                players.Add(playerData);
                count++;
            }

            //Debug.Log($"Total Players Found: {players.Count}");
            /*
            foreach (var player in players)
            {
                Debug.Log($"Player: {player.playerName} | XP: {string.Join(",", player.playerExperience)} | Customization: {player.playerCustomization}");
            }
            */

            //Now you can process and display the data, for example:
            DisplayTopPlayers(players);
        }
        else
        {
            Debug.LogError("No valid data in JSON.");
        }
    }
    else
    {
        Debug.LogError("No data received/null.");
    }
}

private void DisplayTopPlayers(List<FireBase.PlayerData> players)
{
    //Sort players by best score
    var sortedByScores = players.OrderByDescending(player => player.playerExperience.Max()).ToList();
    //Sort players by the highest level completed
    var sortedByLevels = players.OrderByDescending(player => GetHighestLevel(player)).ToList();

    //Display the top players
    DisplayTopPlayersByCategory(sortedByLevels, sortedByScores);
}

    public void DisplayErrorObject(string error)
    {
        errorText.text = error;
        Debug.LogError(error);
    }

    //Gets the highest level played by the players
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

    //Get the best score from all the players
    private float GetBestScore(FireBase.PlayerData player)
    {
        return player.playerExperience != null && player.playerExperience.Length > 0
            ? player.playerExperience.Max()
            : 0f;
    }

    //Displays to the Leaderboard scene
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
