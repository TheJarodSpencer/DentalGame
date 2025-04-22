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
    public GameObject notes;
    public GameObject forms;
    public GameObject meds;

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

    public void OnClickNotes(){
        notes.SetActive(true);
        forms.SetActive(false);
        meds.SetActive(false);
    }

    public void OnClickForms(){
        notes.SetActive(false);
        forms.SetActive(true);
        meds.SetActive(false);
    }

    public void OnClickMeds(){
        notes.SetActive(false);
        forms.SetActive(false);
        meds.SetActive(true);
    }

}
