using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    

    private AudioSource audioSource;
    public GlobalVariables GV;
    public AudioClip song;
    //public AudioClip intro;
    //public AudioClip loop;
    //public double delayAdjust = 0f;
    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        GV = GetComponent<GlobalVariables>();

        
        audioSource.volume = GV.getAudioVolume() / 10f;
        audioSource.clip = song;
        audioSource.loop = true;
        audioSource.Play();

        //double startTime = AudioSettings.dspTime;

        //audioSource.clip = intro;
        //audioSource.PlayScheduled(startTime);

        //double loopStartTime = startTime + intro.length - delayAdjust;
        //audioSource.PlayScheduled(loopStartTime);
       
        //StartCoroutine(PlayIntroThenLoop(loopStartTime));
    }
    void Update()
    {
        audioSource.volume = GV.getAudioVolume() / 10f;
    }
    /*private IEnumerator PlayIntroThenLoop(double time)
    {
        
        double waitTime = time - AudioSettings.dspTime;
        if(waitTime > 0)
        {
            yield return new WaitForSeconds((float)waitTime);
        }
        audioSource.clip = loop;
        audioSource.loop = true;
        audioSource.Play();
    }*/



}
