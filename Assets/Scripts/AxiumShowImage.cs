using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxiumShowImage : MonoBehaviour
{
    public Image targetImage; //Source Image Spot
    public Sprite newSprite;  //Set new one with Patient Pick

    void Start()
    {
        if (targetImage != null && newSprite != null)
        {
            targetImage.sprite = newSprite;  
        }
        else
        {
            Debug.LogWarning("Target Image is missing!");
        }
    }

}
