using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacterPOS : MonoBehaviour
{
    /*
     void Start()
    {
        // Find the specific character GameObject
        //GameObject character = GameObject.Find("MCharacter");
        GameObject character = GameObject.FindGameObjectWithTag("Player");


        if (character != null && KeepPlayerPOS.Instance.GetPlayerPosition() != Vector3.zero)
        {   
            Debug.Log("in character is not null");
            KeepPlayerPOS.Instance.SetPlayerPositionToStored(character);//Load the character in scene a previous pos
            
        }
        else
        {
            Debug.LogError("Character GameObject not found in the scene!");
        }
    }
*/
    IEnumerator Start() {
        yield return new WaitForSeconds(0.1f);
        GameObject player = GameObject.FindWithTag("Player");

        if (player == null)
            Debug.LogError("Player not found!");
        else
            Debug.Log("Player found: " + player.name);
    }
}
