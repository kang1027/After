using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Potal : MonoBehaviour
{
    public GameObject player;
    private string currentMap = "Lobby";    // 현재 맵 이름.
    public int currentMapCount = 0;         // 포탈의 count.

    private AudioSource audioSource;
    public AudioClip portal;



    public Button_A attackButton;

    private Image AttackImg;
    public Sprite pickUpImg;
    private Sprite rollBackImg;
    public static bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();

        AttackImg = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Image>();
        rollBackImg = AttackImg.sprite;
    }

    void Update(){

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if(AttackImg.sprite != pickUpImg)
            {
                AttackImg.sprite = pickUpImg;
                isMove = true;
            }



            if (Input.GetKeyDown(KeyCode.UpArrow) || attackButton.isMoveMap)
            {
                // 윗 키를 눌렀을 때
                // 각 포탈이 가지고 있는 count를 가져와서 해당 포탈일 경우 맵 이름 바꿈.

                if (currentMapCount == 0)
                {
                    GameManager.moveMapName = "WayMap1";
                }
                else if (currentMapCount == 1)
                {
                    GameManager.moveMapName = "WayMap2";
                }
                else if (currentMapCount == 2)
                {
                    GameManager.moveMapName = "WayMap3";
                }
                else if (currentMapCount == 3)
                {
                    GameManager.moveMapName = "WayMap4";
                }
                else if (currentMapCount == 4)
                {
                    GameManager.moveMapName = "WayMap5";
                }
                else if (currentMapCount == 5)
                {
                    GameManager.moveMapName = "WayMap6";
                }
                else if (currentMapCount == 6)
                {
                    GameManager.moveMapName = "StartMap1";
                }
                else if (currentMapCount == 7)
                {
                    GameManager.moveMapName = "StartMap2";
                }
                else if (currentMapCount == 8)
                {
                    GameManager.moveMapName = "StartMap3";
                }
                else if (currentMapCount == 9)
                {
                    GameManager.moveMapName = "StartMap4";
                }
                else if (currentMapCount == 10)
                {
                    GameManager.moveMapName = "StartMap5";
                }
                else if (currentMapCount == 11)
                {
                    GameManager.moveMapName = "StartMap6";
                }
                else if (currentMapCount == 12)
                {
                    GameManager.moveMapName = "BattleMap1";
                }
                else if (currentMapCount == 13)
                {
                    GameManager.moveMapName = "BattleMap2";
                }
                else if (currentMapCount == 14)
                {
                    GameManager.moveMapName = "BattleMap3";
                }
                else if (currentMapCount == 15)
                {
                    GameManager.moveMapName = "BattleMap4";
                }
                else if (currentMapCount == 16)
                {
                    GameManager.moveMapName = "BattleMap5";
                }
                else if (currentMapCount == 17)
                {
                    GameManager.moveMapName = "BattleMap6";
                }
                else if (currentMapCount == 18)
                {
                    GameManager.moveMapName = "WayMap1-2";
                }
                else if (currentMapCount == 19)
                {
                    GameManager.moveMapName = "WayMap2-2";
                }
                else if (currentMapCount == 20)
                {
                    GameManager.moveMapName = "WayMap3-2";
                }
                else if (currentMapCount == 21)
                {
                    GameManager.moveMapName = "WayMap4-2";
                }
                else if (currentMapCount == 22)
                {
                    GameManager.moveMapName = "WayMap5-2";
                }
                else if (currentMapCount == 23)
                {
                    GameManager.moveMapName = "WayMap6-2";
                }

                if(!GunRotate.startGame)// 주위에 적이 없을 경우.
                {
                    GameManager.isMoveMap = true;   // 맵 이동 가능.
                    audioSource.PlayOneShot(portal);
                attackButton.isMoveMap = false;

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AttackImg.sprite = rollBackImg;
        isMove = false;
    }


}
