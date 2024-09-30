using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//To load another scene
using TMPro;//I used TextMeshPro for the button creation so including this

public class ButtonMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("_Scene_0");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
