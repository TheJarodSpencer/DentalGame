using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFadeIn : MonoBehaviour
{

    private CanvasGroup cv;

    private float temp;

    private Vector3 scaleUp = new Vector3(0.1f,0.1f,0.1f);

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
        transform.localScale = new Vector3(0.6f,0.6f,0.6f);
        Invoke("FadeIn", 0.1f);
    }

    void FadeIn() {
        if(temp < 0.5f) {
            temp += 0.1f;
            cv.alpha = temp;
            transform.localScale += scaleUp;
            Invoke("FadeIn", 0.05f);
        } 
        else {
            cv.alpha = 1;
            transform.localScale = new Vector3(1f,1f,1f);
            temp = 0.0f;
        }
    }
}
