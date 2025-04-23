using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingSoundHandler : MonoBehaviour
{
    public AudioClip voice;
    private AudioSource talk;
    public GlobalVariables GV;
    private bool isPlaying = false;
    void Start()
    {
        //NOTE, volume is a value saved from 1.0-0.0. When pulled from GlobalVariables it has to be divided by 10. 
        talk = GetComponent<AudioSource>();
        talk.volume = GV.getAudioVolume() / 10f;
        talk.loop = true;
        talk.clip = voice;
        talk.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if(GV.getTalkingSound())
        {
            if(!isPlaying)
            {
                isPlaying = true;
                talk.Play();
            }
        }else{
            if(isPlaying)
            {
                isPlaying = false;
                talk.Stop();
            }
        }
    }
}
