using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorCameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;

    private float offsetY; // Stores initial Y position
    private float offsetZ; // Stores initial Z position

    void Start()
    {
        if (player != null)
        {
            //Capture the initial Y and Z 
            offsetY = transform.position.y;
            offsetZ = transform.position.z;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            //Update the camera position of X-axis
            Vector3 targetPosition = new Vector3(player.position.x, offsetY, offsetZ);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
