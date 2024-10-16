using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confirmation : MonoBehaviour
{
    public GlobalVariables gv;
    public Button submitButton;
    public Button backButton;
    //confirmation buttons
    public Button confirmButton;
    public Button returnButton;
    //canvas's
    public Canvas menu;
    public Canvas confMenu;
    void Start()
    {
        menu.enabled = true;
        confMenu.enabled = false;
        submitButton.onClick.AddListener(submitButtonOnClick);
        backButton.onClick.AddListener(backButtonOnClick);

    }
    void submitButtonOnClick()
    {
        Debug.Log("" + gv.getCharacterID());
        menu.enabled = false;
        confMenu.enabled = true;
        confirmButton.onClick.AddListener(confirmButtonOnClick);
        returnButton.onClick.AddListener(returnButtonOnClick);
    }
    void backButtonOnClick()
    {
        //return to the previous scene
    }
    void confirmButtonOnClick()
    {
        //sends off the code from gv.getCharacterID()
    }
    void returnButtonOnClick()
    {
        menu.enabled = true;
        confMenu.enabled = false;
    }

}
