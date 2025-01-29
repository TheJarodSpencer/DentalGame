using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFadeIn : MonoBehaviour
{

    private CanvasGroup cv;

    private float temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable() {
        cv = GetComponent<CanvasGroup>();
        temp = 0.0f;
        cv.alpha = temp;
        Invoke("FadeIn", 0.2f);
    }

    void FadeIn() {
        if(temp < 1.0f) {
            temp += 0.1f;
            cv.alpha = temp;
            Invoke("FadeIn", 0.2f);
        } 
        else {
            cv.alpha = 1;
            temp = 0.0f;
        }
    }
}
