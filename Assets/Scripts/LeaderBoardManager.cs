using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; //OrderByDescending
using TMPro;

using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;

[System.Serializable]
public class WrapperList
{
    public List<FireBase.PlayerData> players;
}

public class LeaderBoardManager : MonoBehaviour
{
    public TextMeshProUGUI outputText;  //For Output
    public TextMeshProUGUI errorText;

    void Start()
    {
        GetTop10Players();
    }

    public void GetTop10Players()
    {
        Debug.Log("In top10 players");
        string collectionPath = "players"; //Collect player name

        //Fetch all player data
        FirebaseFirestore.GetDocumentsInCollection(collectionPath, "LeaderBoardManager", "DisplayData", "DisplayErrorObject");
        Debug.Log("ProcessedCollection");
    }

    public void DisplayData(string data)
    {
        Debug.Log("In DisplayData LB");

        if (!string.IsNullOrEmpty(data) && data != "null")
        {
            Debug.Log("Raw Data: " + data);

            //Parse JSON
            WrapperList wrapper = JsonUtility.FromJson<WrapperList>("{\"players\":" + data + "}");
            Debug.Log($"Total Players Found: {wrapper.players.Count}");

            if (wrapper != null && wrapper.players != null && wrapper.players.Count > 0)
            {
                foreach (var player in wrapper.players)
                {
                    Debug.Log($"Player: {player.playerName}, Level Count: {player.playerExperience.Length}, Best Score: {GetBestScore(player)}");
                }

                //Grab top 10 players
                List<FireBase.PlayerData> players = wrapper.players.OrderByDescending(player => GetHighestLevel(player))
                    .ThenByDescending(player => GetBestScore(player))
                    .Take(10)
                    .ToList();

                DisplayTopPlayers(players);
            }
            else
            {
                DisplayError("No valid player data found.");
            }
        }
        else
        {
            DisplayError("No data received.");
        }
    }

    public void DisplayErrorObject(string error)
    {
        errorText.text = error;
        Debug.LogError(error);
    }

    private int GetHighestLevel(FireBase.PlayerData player)
    {
        return player.playerExperience != null ? player.playerExperience.Length : 0;
    }

    private float GetBestScore(FireBase.PlayerData player)
    {
        return player.playerExperience != null && player.playerExperience.Length > 0 ? player.playerExperience.Max() : 0f;
    }

    private void DisplayTopPlayers(List<FireBase.PlayerData> players)
    {
        outputText.text = "Top 10 Players:\n";
        foreach (var player in players)
        {
            outputText.text += $"{player.playerName} - Level: {GetHighestLevel(player)}, Best Score: {GetBestScore(player)}\n";
        }
    }

    public void DisplayError(string error)
    {
        errorText.text = error;
        Debug.LogError(error);
    }
}
