using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatboxHandler : MonoBehaviour
{
    public Transform player;
    public float xThreshold = 2f;
    public float zThreshold = 2f;
    public Material[] objMat;
    //0 = not close
    //1 = close
    //2 = mouse hovering
    private float initialPosX;
    private float initialPosZ;
    void Start()
    {
        initialPosX = transform.position.x;
        initialPosZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = player.position.x;
        float playerZ = player.position.z;

        Vector3 thisPos = transform.position;

        float distanceFromObjX = playerX-thisPos.x;
        float distanceFromObjZ = playerZ-thisPos.z;

        if(Mathf.Abs(distanceFromObjX)> xThreshold && Mathf.Abs(distanceFromObjZ) > zThreshold)
        {
            
        }

    }
}
