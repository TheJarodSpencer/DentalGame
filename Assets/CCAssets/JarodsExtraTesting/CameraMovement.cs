using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float xThreshold = 2f;

    private float initialCameraX;
   
    void Start()
    {
        initialCameraX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = player.position.x;

        Vector3 cameraPos = transform.position;

        float distanceFromCenter = playerX-cameraPos.x;

        if(Mathf.Abs(distanceFromCenter) > xThreshold)
        {
            float targetX = Mathf.Lerp(cameraPos.x, playerX, followSpeed * Time.deltaTime);

            transform.position = new Vector3(targetX, cameraPos.y, cameraPos.z);
        }
    }
}
