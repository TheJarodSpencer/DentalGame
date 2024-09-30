using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//how to work with the text

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private Text uiText;

    void Start()
    {
        //Searches GameObject that score counter attached to
        uiText = GetComponent<Text>();
    }

    void Update()
    {
        //String representation of the int score
        uiText.text = score.ToString("#,0"); //This is a zero
    }
}
