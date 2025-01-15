using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoors : MonoBehaviour
{
    [Header("Inscribed")]
    public string sceneToLoad;
    public GameObject[] indicatorCubes; // Array of indicator cubes
    public GameObject levelSelector;
    public GameObject pickedLevel;

    private void Start()
    {
        // Ensure all indicator cubes are inactive at the start
        foreach (GameObject cube in indicatorCubes)
        {
            cube.SetActive(false);
        }
    }

    // Player trigger door
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            Debug.Log("Player entered the trigger.");
            // Activate all indicator cubes when the player enters
            foreach (GameObject cube in indicatorCubes)
            {
                cube.SetActive(true);
            }
        }
    }

    // Press E to enter level
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
           ReplacePrefab();
        }
    }

    // Player exits
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Deactivate all indicator cubes when the player exits
            foreach (GameObject cube in indicatorCubes)
            {
                cube.SetActive(false);
            }
        }
    }

    private void ReplacePrefab()
    {
        if(levelSelector != null && pickedLevel)
        {
            Vector3 oldPos = levelSelector.transform.position;
            Quaternion oldRotation = levelSelector.transform.rotation;

            Destroy(levelSelector);

            GameObject newObject = Instantiate(pickedLevel, oldPos, oldRotation);

            // Optional: If there are physics issues, you can disable Rigidbody or other components on the new prefab
            Rigidbody rb = newObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Disable Rigidbody if it has one (to prevent physics interference)
                rb.isKinematic = true;
            }
        }   
    }


}
























/*
public class EnterDoors : MonoBehaviour
{
    [Header("Inscribed")]
    public string sceneToLoad;
    public GameObject popupPanel;
    public TextMeshProUGUI doorText;
    public string levelMessage;
    //Add prefab and drag inspector

    private void Start()
    {
        doorText.gameObject.SetActive(false);
        popupPanel.SetActive(false); // Ensure popupPanel is inactive at start
    }

    // When Player collides with door
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // If the object that collides is tagged Player
        {
            doorText.text = levelMessage; // Set the unique text for the level
            doorText.gameObject.SetActive(true); // Show the door text
            popupPanel.SetActive(true); // Show the popup panel
        }
    }

    // If player still there and presses E
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // If player leaves
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popupPanel.SetActive(false); // Hide the popup panel
            doorText.gameObject.SetActive(false); // Hide the door text
        }
    }
}
*/
