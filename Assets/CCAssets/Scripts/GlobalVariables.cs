using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    //Character ID: 
    //first digit = sexID: 1=male 2=female
    //second digit = hairID: 0=none, 1=short, 2=ponytail
    //third digit = hairColorID: 0=black, 1=blonde, 2=brown, 3=orange, 4=red
    //fourth digit = skinID
    //fifth digit = clothesColorID: 0=cyan, 1=black, 2=grey, 3=blue, 4=orange, 5=purple, 6=pink,7=red, 8=white, 9=yellow.
    //sixth digit = labcoat bool: 0=no 1=yes
    //seventh digit = glasses bool: 0=no 1=yes
    int characterID = 1110200;
    public int getCharacterID()
    {
        return characterID;
    }
    public void setCharacterID(int newID)
    {
        characterID = newID;
    }

}
