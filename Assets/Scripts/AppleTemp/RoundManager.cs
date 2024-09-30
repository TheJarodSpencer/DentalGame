using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public Text roundNumText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextRound(int basketNum)
    {
        roundNumText.text = "ROUND: " + basketNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
