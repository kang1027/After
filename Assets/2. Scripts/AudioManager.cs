using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource au;
    
    private float currentTime = 0;
    public float delayTime = 0.2f;
    void Start()
    {
        au = GetComponent<AudioSource>();
    }
    void Update()
    {
    }
    public void AM(AudioClip walk, float delayTime = 0.2f){
        au.clip = walk;
        this.delayTime = delayTime;
        if (Time.time > currentTime + delayTime)
        {
            currentTime = Time.time;
            au.PlayOneShot(walk);
        }
    }
    public void MonsterDeath(AudioClip clip, float volumn = 0.5f){
        au.volume = volumn;
        au.PlayOneShot(clip);

    }
}
