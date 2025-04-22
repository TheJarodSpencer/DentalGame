using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource FXSource;
    public Button[] settingsButton;
    public GlobalVariables GV;
    public Canvas mainMenu;
    public Canvas settingsMenu;
    public Slider volSlider;
    private bool onSettings = false;
    int volume;
    void Start()
    {
        volume = GV.getAudioVolume();
        musicSource.volume = GV.getAudioVolume() / 10f;
        FXSource.volume = GV.getAudioVolume() / 10f;
        volSlider.value = volume / 10f;
        settingsButton[0].onClick.AddListener(settingsButtonOnClick);
        settingsButton[1].onClick.AddListener(settingsButtonOnClick);
        settingsMenu.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(onSettings)
        {
            if((volume / 10) != volSlider.value)
            {
                volume = (int)(volSlider.value * 10f);
                musicSource.volume = volume / 10f;
                FXSource.volume = volume / 10f;
                GV.setAudioVolume(volume);
            }
        }
    }
    public void settingsButtonOnClick()
    {
        if(!onSettings)
        {
            onSettings = true;
            mainMenu.enabled = false;
            settingsMenu.enabled = true;
        }else{
            onSettings = false;
            mainMenu.enabled = true;
            settingsMenu.enabled = false;
        }
    }
    
}
