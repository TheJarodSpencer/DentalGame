using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnFloorOneButton(){
        SceneManager.LoadScene("LevelSelectorMainFloor");
    }
}
