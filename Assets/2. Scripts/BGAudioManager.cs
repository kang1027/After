using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudioManager : MonoBehaviour
{
    private AudioSource ase;
    public bool isBattle;
    // Start is called before the first frame update
    void Start()
    {
        ase = GetComponent<AudioSource>();
    }


    public void PlayBGM(AudioClip bgmClip=null, float sound = 0.5f){
        if(isBattle)
            ase.Stop();
            else{
        ase.clip = bgmClip;
        ase.volume = sound;
        ase.Play();
        isBattle = false;
            }

    }
}
