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

    }



}
