//This script is attached to the Elevator scene that handles what button the user presses on to go to a certain floor
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorButtonManager : MonoBehaviour
{
    //Go to Main Floor on 1
    public void OnFloorOneButton(){
        SceneManager.LoadScene("LevelSelectorMainFloor");
    }

    //Go to LevelSelector Floor 2 on 2
    public void OnFloor2Button(){
        SceneManager.LoadScene("LevelSelector2ndFloor");
    }

    //Can further implement for Floor 3 here and add more levels in the UI and include buttons!
}
