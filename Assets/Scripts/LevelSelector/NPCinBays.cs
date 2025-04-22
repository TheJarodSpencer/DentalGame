using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCinBays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float[] experience = PlayerSaveData.Instance.GetPlayerExperience();

        if (experience == null)
        {
            Debug.LogWarning("Player EXP NULL");
            return;
        }

        for (int i = 0; i < experience.Length; i++)
        {
            if (experience[i] != 0f)
            {
                string npcName = "NPC" + i;
                GameObject npc = GameObject.Find(npcName);

                if (npc != null)
                {
                    npc.SetActive(false);
                }
                else
                {
                    Debug.LogWarning("No NPC");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
