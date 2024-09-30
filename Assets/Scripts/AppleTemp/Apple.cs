using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;//static fields do not appear in inspector

    void Update()
    {
        if(transform.position.y < bottomY){//Destroys apples that reach -20 off screen
            Destroy(this.gameObject);
            //Notify Apples were Missed
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();//reference to ApplePicker component of main camera
            apScript.AppleMissed();//call applemissed
        }
    }
}
