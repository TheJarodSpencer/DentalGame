using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 1000f;
    public float xThreshold = 2f;
    public Vector3 offset = new Vector3(0,0, -10);
    public GlobalVariables GV;
    public float zoomSpeed = .5f;
    private Camera cam;
    private bool zoomed = false;
    private Vector3 originalPosition;
    private float initialCameraX;
    private float initialCameraY = 4.05f;
    private float initialCameraZ = -8.94f;
    private bool isZooming = false;
    private float originalSize;
    void Start()
    {
        cam = GetComponent<Camera>();
        initialCameraX = transform.position.x;
        originalPosition = transform.position;
        originalSize = cam.orthographicSize;
    }
    void Update()
    {
        float playerX = player.position.x;
        Vector3 cameraPos = transform.position;
        float distanceFromCenter = playerX-cameraPos.x;
        if(!GV.isTalking())
        {
            if(zoomed)
            {
                zoomed = false;
                StartCoroutine(ZoomBackOut());
            }else{
                if(transform.position.z != initialCameraZ || transform.position.y != initialCameraY)
                {
                    StartCoroutine(ZoomBackOut());
                }
            }
            if(Mathf.Abs(distanceFromCenter) > xThreshold)
            {
                float targetX = Mathf.Lerp(cameraPos.x, playerX, followSpeed * Time.deltaTime);
                
                Vector3 targetPosition = new Vector3(targetX, cameraPos.y, cameraPos.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
            }
        }else{
            //Camera zoom in animation.
            if(!zoomed)
            {
                zoomed = true;
                originalPosition.x = transform.position.x;
                StartCoroutine(ZoomToSize(1));
            }
        }
        
    }
    private IEnumerator ZoomToSize(float targetSize)
    {
        isZooming = true;
        Vector3 targetPosition = player.position + offset;
        while(Mathf.Abs(cam.orthographicSize - targetSize) > 0.01f || Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPosition, zoomSpeed * Time.deltaTime);
            yield return null;
        }
        cam.orthographicSize = targetSize;
        transform.position = targetPosition;
    }
    private IEnumerator ZoomBackOut()
    {
        Vector3 targetPosition = new Vector3(originalPosition.x, initialCameraY, initialCameraZ);
        while(Mathf.Abs(cam.orthographicSize - originalSize) > 0.01f || Vector3.Distance(transform.position, targetPosition)> 0.01f)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, originalSize, zoomSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPosition, zoomSpeed * Time.deltaTime);
            yield return null;
        }
        cam.orthographicSize = originalSize;
        transform.position = targetPosition;
        isZooming = false;
    }
}
