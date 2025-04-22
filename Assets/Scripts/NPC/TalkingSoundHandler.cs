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
        talk = GetComponent<AudioSource>();
        //also set talk vol here and what not
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
