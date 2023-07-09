using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Button : MonoBehaviour
{
    public AudioClip clickClip;
    private GameObject am;
    private GameObject bam;

    public Canvas pauseCanvas;
    public GameManager gm;

    public GameObject gameOverUI;

    public AudioSource bgmAs;

    Image a;
    public Sprite stop2;
    public GameObject player;
    public void Start(){
        am = GameObject.Find("AudioManager");
        bam = GameObject.Find("BGAudioManager");
        // a.sprite = this.GetComponent<Image>().sprite;
        // this.GetComponent<Image>().sprite = a.sprite;
    }
    public void GameStart(){
        am.GetComponent<AudioManager>().AM(clickClip);
        DontDestroyOnLoad(bam);
        DontDestroyOnLoad(am);
        Controllor_rkd.playerHp = 8;
        bam.GetComponent<AudioSource>().enabled=true;
        SceneMovePotal.currentSceneCount = 1;   // 씬(Stage)의 이동 변수.
        SceneManager.LoadScene(4);
        GameManager.startTime = Time.time;
    }
    public void Pause(){
        this.GetComponent<Image>().sprite  = stop2;
        bam.GetComponent<AudioSource>().enabled=false;
        Time.timeScale = 0;
        pauseCanvas.gameObject.SetActive(true); 
    }
    
    public void Exit(){
        Application.Quit();
        bam.SetActive(true);
    }

    public void Home(){
        Controllor_rkd.playerHp = 5;
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(0);
        bam.SetActive(true);
        Time.timeScale = 1;
        bgmAs.Stop();
        GameManager.currentCoine = 0;
        GameManager.gameClear = false;
    }

    public void Continue(){        
        bam.GetComponent<AudioSource>().enabled=true;
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void GunChoice(){
            Controllor_rkd.currentWeaponNum = 0;
            Controllor_rkd.aa = true;

            player.GetComponent<Controllor_rkd>().aaaa();
    }
    public void SwordChoice(){
            Controllor_rkd.currentWeaponNum = 1;
            Controllor_rkd.aa = true;   
            player.GetComponent<Controllor_rkd>().aaaa();
            }
    public void BowChoice(){
            Controllor_rkd.currentWeaponNum = 2;
             Controllor_rkd.aa = true;   
            player.GetComponent<Controllor_rkd>().aaaa();
            
        }

}
