using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_Bow : MonoBehaviour
{
    public GameObject[] chagingImage;

    public GameObject arrow;    // 화살
    public Transform shootPosition; // 발사위치

    private float chagingDamage = 0.0f;
    public float bowDamage = 0.0f;

    public Sprite chagingImg;
    private Sprite unChagingImg;
    private AudioSource audioSource;
    public AudioClip chaging;
    public AudioClip shoot;

    public Button_A attackButton;
  
  private bool isBowChaging;
    void Start()
    {
        unChagingImg = gameObject.GetComponent<SpriteRenderer>().sprite;
        audioSource = GetComponent<AudioSource>();
        for(int i = 0; i < chagingImage.Length; i++)
            chagingImage[i].gameObject.SetActive(false);
    }

    void Update(){
        if(!attackButton.aTouch && isBowChaging)
        {
            JoyStickShooting();
            isBowChaging = false;
            attackButton.isShoot = false;
        }
    }
    public void Shoot()
    {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine("BowShoot");
            }
            if(Input.GetKeyUp(KeyCode.Space))
            {
                audioSource.Stop();
                audioSource.PlayOneShot(shoot);
                Instantiate(arrow, shootPosition.position, transform.rotation);
                bowDamage = chagingDamage;
                chagingDamage = 0;
                StopCoroutine("BowShoot");
                gameObject.GetComponent<SpriteRenderer>().sprite = unChagingImg;
                for (int i = 0; i < chagingImage.Length; i++)
                    chagingImage[i].gameObject.SetActive(false);
            }
        
        //Instantiate(arrow, shootPosition.position, transform.rotation);
    }

    public void JoystickShoot(){
        attackButton.isShoot = true;

        isBowChaging = true;
        StartCoroutine("BowShoot");
    }

    public void JoyStickShooting(){
        audioSource.Stop();
        audioSource.PlayOneShot(shoot);
        Instantiate(arrow, shootPosition.position, transform.rotation);
        bowDamage = chagingDamage;
        chagingDamage = 0;
        StopCoroutine("BowShoot");
        gameObject.GetComponent<SpriteRenderer>().sprite = unChagingImg;
        for (int i = 0; i < chagingImage.Length; i++)
            chagingImage[i].gameObject.SetActive(false);
    }

    IEnumerator BowShoot()  // 공격버튼 클릭 시 0.2초의 딜레이마다 총알 발사.
    {
        audioSource.PlayOneShot(chaging);
        for(int i = 0; i<5; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = chagingImg;
            chagingDamage += 5.0f;
            chagingImage[i].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }

}
