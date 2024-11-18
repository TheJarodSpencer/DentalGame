using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //public Camera cam;
    //public GameObject character;
    public GlobalVariables GV;
    public float speed = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        if(!GV.isTalking() && !GV.isPaused())
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
    }
}
