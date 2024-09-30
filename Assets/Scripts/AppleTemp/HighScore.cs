using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//uGUI to work need this

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT; //hides from other classes
    static private int _SCORE = 1000; 
    private Text txtCom; //reference to GOs Text component

    void Awake(){
        _UI_TEXT = GetComponent<Text>();
        //PlayerPrefs Highscore already exsists, read it
        if(PlayerPrefs.HasKey("HighScore")){
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE{//any other script can read the value of _SCORE
        get{return _SCORE;}
        private set{
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);//PlayerPref set everytime SCORE is also called
            if(_UI_TEXT != null){
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry){//if higher score will set it
        if(scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    //TO EASILY RESET THE PLAYERPREF HIGHSCORE
    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos(){ //can be called when game and game is not running
        if(resetHighScoreNow){
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
        }
    }
}
