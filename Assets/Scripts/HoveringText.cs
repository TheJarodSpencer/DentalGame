using UnityEngine;
using UnityEngine.EventSystems;

public class HoveringText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverText; // Assign the text GameObject in the Inspector

    // Called when the mouse pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverText.SetActive(true); // Show the text
    }

    // Called when the mouse pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        hoverText.SetActive(false); // Hide the text
    }
}
