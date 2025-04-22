using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SettingsAudio : MonoBehaviour
{

    public Slider volSlider;

    public GlobalVariables GV;

    public AudioSource musicSource;

    public Toggle t;

     int volume;
    // Start is called before the first frame update
    void Start()
    {
        volume = GV.getAudioVolume();
        musicSource.volume = GV.getAudioVolume() / 10f;
        volSlider.value = volume / 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(t.isOn) {
            volume = 0;
            musicSource.volume = 0f;
            GV.setAudioVolume(volume);
        }
        else if((volume / 10) != volSlider.value)
            {
                volume = (int)(volSlider.value * 10f);
                musicSource.volume = volume / 10f;
                GV.setAudioVolume(volume);
            }
    }
}
