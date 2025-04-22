using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoveringTextWelcome : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text hoverText;

    // Called when the mouse pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverText.color = Color.green; // Change the text to green on hover
    }

    // Called when the mouse pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        hoverText.color = Color.black; // Change the text back to origianl color
    }
}
