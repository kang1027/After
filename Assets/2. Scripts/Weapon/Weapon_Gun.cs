using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun : MonoBehaviour
{
    public GameObject bullt;    // 총알
    public Transform shootPosition; // 발사위치

    public ParticleSystem gunPt;    // 총구섬광

    public float delay = 1.0f;
    private float currentTime = 0;
    public Button_A attackButton;
    private AudioSource audioSource;
    public AudioClip shoot;
    


    public void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(delay <  Time.time-currentTime)
            {            
                audioSource.volume = 0.2f;
                audioSource.PlayOneShot(shoot);
                currentTime = Time.time;
                Instantiate(bullt, shootPosition.position, transform.rotation);
                gunPt.Play();
            }
        }
    }
    public void JoystickShoot() {
        StartCoroutine("GunShoot");
    }
    IEnumerator GunShoot()  // 공격버튼 클릭 시 0.2초의 딜레이마다 총알 발사.
    {
        Instantiate(bullt, shootPosition.position, transform.rotation);
        audioSource.volume = 0.1f;
        audioSource.PlayOneShot(shoot);
        gunPt.Play();
        attackButton.isShoot = true;
        yield return new WaitForSeconds(0.2f);
         attackButton.isShoot = false;
    }

}
