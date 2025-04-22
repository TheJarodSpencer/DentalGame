using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorOpen : MonoBehaviour
{
    private bool playerInRange = false;

    void OnTriggerEnter(Collider cube)
    {
        if (cube.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered the trigger zone");
        }
    }

    void OnTriggerExit(Collider cube)
    {
        if (cube.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited the trigger zone");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed. Loading scene...");
            //SceneManager.LoadScene("ElevatorScene");
        }
    }
}
