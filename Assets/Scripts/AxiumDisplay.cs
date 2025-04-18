using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AxiumDisplay : MonoBehaviour
{
    public Image targetImage;
    public Sprite newSprite;  
    public TextAsset noteText;
    public TextAsset medHistoryText;
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        //Takes Care of Image
        if (targetImage != null && newSprite != null)
        {
            targetImage.sprite = newSprite;  
        }
        else
        {
            Debug.LogWarning("Target Image is missing!");
        }

        //Takes care of note
        if (noteText != null && textMeshPro != null)
        {
            textMeshPro.text = noteText.text;
        }
        else
        {
            Debug.LogWarning("Note text is missing!");
        }

        //Takes care of med note
        if (medHistoryText != null && textMeshPro2 != null)
        {
            textMeshPro2.text = medHistoryText.text;  
        }
        else
        {
            Debug.LogWarning("MedHistory text is missing!");
        }

    }



}
