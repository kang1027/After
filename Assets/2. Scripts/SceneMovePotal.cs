using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneMovePotal : MonoBehaviour
{
    public static int currentSceneCount = 1;   // 씬(Stage)의 이동 변수.

    public Image gameClearImg;
    // Start is called before the first frame update
    private AudioSource b;

    public GameObject time;

    private GameManager gm;
    void Start()
    {
        b = GameObject.Find("BGAudioManager").GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")  
        {
            if(currentSceneCount==1)
                DontDestroyOnLoad(time);
            b.Stop();
            currentSceneCount++;
            GameManager.moveMapName = null;
            if(currentSceneCount==4)
            {
                GameManager.gameClear = true;
                gameClearImg.gameObject.SetActive(true);         

            }
            else
            {
                SceneManager.LoadScene(4);
            }
            //DontDestroyOnLoad(GameObject.Find("Time"));
            

        }
    }
}
