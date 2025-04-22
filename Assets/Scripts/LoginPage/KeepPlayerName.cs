using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerName : MonoBehaviour
{
    public static KeepPlayerName Instance;
    public string playerName;

    [SerializeField]
    private int volume = 5;
   
    void Awake()
    {
        if(Instance == null){
            Instance = this;
            //volume = 5;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Not destroying");
        }
        else{
            Destroy(gameObject);
            Debug.Log("Destroyed for some reason");
        }
    }

    public void SetCharacterName(string name){
        playerName = name;
        Debug.Log("In Keep playername its set to: " + playerName);
    }

    public string GetCharacterName(){
        Debug.Log("In Keep playername get character name its set to: " + playerName);
        return playerName;
    }

    public void SetVolume(int v){
        volume = v;
        //Debug.Log("In Keep playername its set to: " + playerName);
    }

    public int GetVolume(){
        //Debug.Log("In Keep playername get character name its set to: " + playerName);
        return volume;
    }
}
