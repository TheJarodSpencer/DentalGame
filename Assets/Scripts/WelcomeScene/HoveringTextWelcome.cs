using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoveringTextWelcome : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text hoverText; // Assign the text GameObject in the Inspector

    // Called when the mouse pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverText.color = Color.green; // Show the text
    }

    // Called when the mouse pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        hoverText.color = Color.black; // Hide the text
    }
}
