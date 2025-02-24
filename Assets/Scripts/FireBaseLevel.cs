using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseLevel : MonoBehaviour
{
    public LevelButtonManager LBM;

    public string numberToTrackQuestions = "1101588";
    public int countOfQuestions = 0;
    public float totalPercentWorth = 50f;
    public float questionWorth = 0f;
    public TextAsset npcScript;//Script the NPC speaking

    public void Start()
    {
        //Finds how many questions there are to get the rigth perctange of points 
        string[] lines = npcScript.text.Split('\n');
        foreach(string line in lines){
            if(line.Contains(numberToTrackQuestions)){
                countOfQuestions++;
            }
        }
        questionWorth = totalPercentWorth/countOfQuestions;
    }

}
