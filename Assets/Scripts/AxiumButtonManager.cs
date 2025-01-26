using System.Collections.Generic;
using UnityEngine;

public class AxiumButtonManager : MonoBehaviour
{
    [System.Serializable]
    public class ScreenButtonPair
    {
        public string ButtonName; // Optional: For clarity in the Inspector
        public GameObject Screen; // The screen this button corresponds to
    }

    public List<ScreenButtonPair> Screens; // A list of screen-button pairs

    // Called when a button is pressed
    public void ShowScreen(int screenIndex)
    {
        if (screenIndex >= 0 && screenIndex < Screens.Count)
        {
            GameObject screenToShow = Screens[screenIndex].Screen;
            
            foreach (var pair in Screens)
            {
                if (pair.Screen != null)
                {
                    // Activate the selected screen and deactivate others
                    pair.Screen.SetActive(pair.Screen == screenToShow);
                }
            }
        }
    }


}
