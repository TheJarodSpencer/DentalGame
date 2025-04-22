using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*
*
* This Script is responsible to Fading the screen out when leaving a scene
* Before loading a new scene, instatiating a FadeOut prefab will cause the screen 
*   to quickly fade to black
*/

public class FadeOut : MonoBehaviour
{

    [SerializeField]
    private Image b;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponentInChildren<Image>();
        b.color = new Color(0,0,0,0);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Fade", 0.1f);
    }

    private void Fade() {
        time += 0.1f;
        b.color = new Color(0,0,0,b.color.a + 0.01f);

        if (time > 1) {
            return;
        }
        else {
            Invoke("Fade", 0.1f);
        }
    }

}
