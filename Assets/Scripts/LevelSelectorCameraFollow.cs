using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorCameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;

    private float offsetY; 
    private float offsetZ; 

    public bool isOnFloor1 = true; //Track the current floor

    // Camera stop boundaries
    public float stopPosition1X = -70f; //Left boundary
    public float stopPosition2X = 80.5f; //Right boundary

    void Start()
    {
        if (player != null)
        {
            //Capture the initial Y and Z positions
            offsetY = transform.position.y;
            offsetZ = transform.position.z;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, offsetY, offsetZ);

            if (isOnFloor1)
            {
                //Right when on Floor 1
                float clampedX = Mathf.Min(targetPosition.x, stopPosition2X);
                Vector3 clampedPosition = new Vector3(clampedX, offsetY, offsetZ);

                transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);
            }
            else
            {
                //Both sides Floor 2
                float clampedX = Mathf.Clamp(targetPosition.x, stopPosition1X, stopPosition2X);
                Vector3 clampedPosition = new Vector3(clampedX, offsetY, offsetZ);

                transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);
            }
        }
    }
}
