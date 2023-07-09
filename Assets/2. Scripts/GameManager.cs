using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject player;   
    public GameObject[] enemy;  // 몬스터 종류


    private Transform[] childSpawnPos = null;   // 스폰 포인트의 위치.
    private Transform[] WaychildSpawnPos = null;   // 스폰 포인트의 위치.

    public static string moveMapName;   // 현재 맵 이름.
    public Transform[] moveMapPos;      // 이동할 맵 위치.
    public static bool isMoveMap;       // 맵을 이동할 수 있는지 판단.

    public static int currentCoine;     // 현재 코인


    private bool isWay;
    public Text coinText;               
    public Text coinText1;               
    public Image isGameOverImage;       

    public int monsterCount;        // 소환할 몬스터 수.
    public int WaymonsterCount;        // 소환할 몬스터 수.
    public static bool isPlayingGame;   // 게임 시작 여부 판단.

    public Text enemyCountText;

    public int enemyCount=0;

    private BGAudioManager bgam;

    public AudioClip stage1;
    public AudioClip stage2;
    public AudioClip stage3;

    public AudioClip battleClip;
    public bool isChange;

    public int stageBGM = 1;

    public RawImage minimap;
    public Image[] minimap1;

    public Text timeText;
    public Text timeText1;

    public static bool gameClear;



 public static float startTime;   
    public static int currentTIme;

    bool istimeCount;
    GameManager gameManager;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {

        isPlayingGame = true;
        isGameOverImage.gameObject.SetActive(false);   
        Array.Resize(ref childSpawnPos, monsterCount); 
        Array.Resize(ref WaychildSpawnPos, WaymonsterCount);
        bgam = GameObject.Find("BGAudioManager").GetComponent<BGAudioManager>();
        if(stageBGM == 1)
            bgam.PlayBGM(stage1);
        if(stageBGM == 2)
            bgam.PlayBGM(stage2);
        if(stageBGM == 3)
            bgam.PlayBGM(stage3);


        istimeCount = true;

        
            Color _minimap = minimap.color;
            _minimap.a = 0.5f;
            minimap.color = _minimap;
            for(int i = 0; i<minimap1.Length; i++)
            {
                Color _minimap1 = minimap1[i].color;
                _minimap1.a = 0.5f;
                minimap1[i].color = _minimap1;
            }   

            isGameOverImage.gameObject.SetActive(false);
            
    }

    // Update is called once per frame
    void Update()
    {

if(istimeCount)
            currentTIme = (int)(Time.time-startTime);
        if(!isPlayingGame)
        {
            istimeCount = false;
            int maxTime = currentTIme;
            int minuteTime = 0;
            while(maxTime >= 60)
            {
                minuteTime ++;
                maxTime -= 60;
            }
            IsGameOverTimeText(minuteTime,maxTime);
        }
        if(gameClear)
        {
            istimeCount = false;
            int maxTime = currentTIme;
            int minuteTime = 0;
            while(maxTime >= 60)
            {
                minuteTime ++;
                maxTime -= 60;
            }
            isGameClear(minuteTime,maxTime);
        }


        MoveMap();
        ChangeBGM();

        //if (isPlayingGame)
        //{
        //    //Debug.Log("startGame : " + gunRotate.startGame);
        //    //Debug.Log("IsBoxOn : " + isBoxOn);
        //    if (!gunRotate.startGame)
        //    {
        //        for (int i = 0; i < check.Length; i++)
        //        {
        //            Color color = check[i].sr.color;
        //            color.a = 0;
        //            check[i].sr.color = color;
        //            check[i].bx.isTrigger = true;
        //        }
        //    }
        //    else
        //    {
        //        if (isBoxOn)
        //        {
        //            for (int i = 0; i < check.Length; i++)
        //            {
        //                Color color = check[i].sr.color;
        //                color.a = 255f;
        //                check[i].sr.color = color;
        //                check[i].bx.isTrigger = false;
        //            }
        //            isBoxOn = false;
        //        }
        //    }
        //}
    }

    public void ChangeBGM(){
        if(!isChange)
        {
            Color _minimap = minimap.color;
            _minimap.a = 0.5f;
            minimap.color = _minimap;
            for(int i = 0; i<minimap1.Length; i++)
            {
                Color _minimap1 = minimap1[i].color;
                _minimap1.a = 0.5f;
                minimap1[i].color = _minimap1;
            }

            bgam.isBattle = false;
            if(stageBGM == 1)
                bgam.PlayBGM(stage1);
            if(stageBGM == 2)
                bgam.PlayBGM(stage2);
            if(stageBGM == 3)
                bgam.PlayBGM(stage3);
            isChange = true;
        }

    }
    public void EnemyCountUI(){
        GameObject[] enemyCount1 = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemyCount1.Length == 0)
            enemyCountText.gameObject.SetActive(false);
        else{            
            enemyCountText.gameObject.SetActive(true);
            enemyCountText.text = $"Monster : {enemyCount1.Length}";
        }
    }
    private void MoveMap()  // 맵 이동 함수.
    {
        int wayMapSpawnPercent = UnityEngine.Random.Range(1, 101);  // 길에서 확률적인 몬스터 스폰할 랜덤 변수.


        if(isMoveMap)       // 이동 가능할 떄
        {
            // moveMapName을 확인하고 그 이름에 맞으면 이동.
            // 한번 몬스터가 소환되면 그 스폰 포인트는 삭제.
            // 길은 60%가 넘으면 몬스터 소환. BattleMap은 100% 소환.        
            //for(int i = 0; i<24; i++)
            //{
            //    player.transform.position = moveMapPos[i].position;       딕셔너리를 사용하여 **코드 리팩토링**
            //}

            if (moveMapName == "WayMap1")
            {
                player.transform.position = moveMapPos[0].position;
                if(wayMapSpawnPercent >= 60) // 60%가 넘을 경우 길에서 몬스터 생성.      
                {
                    isWay = true;
                    instanceMonster(7);
                }        
                destroySpawner(7);
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap2")
            {
                player.transform.position = moveMapPos[1].position;
                                
                if (wayMapSpawnPercent >= 60)
                {
                    isWay = true;
                    instanceMonster(8);                   
                }

                destroySpawner(8);
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap3")
            { 
                player.transform.position = moveMapPos[2].position;
                  
                if (wayMapSpawnPercent >= 60)
                {
                    isWay = true;
                    instanceMonster(9);
                }
                    
                destroySpawner(9);
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap4")
            {
                player.transform.position = moveMapPos[3].position;
                  
                if (wayMapSpawnPercent >= 60)
                {
                    isWay = true;
                    instanceMonster(10);
                }
                    
                destroySpawner(10);
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap5")
            {
                player.transform.position = moveMapPos[4].position;
                  
                if (wayMapSpawnPercent >= 60)
                {
                    isWay = true;
                    instanceMonster(11);
                }
                    
                destroySpawner(11);
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap6")
            {
                player.transform.position = moveMapPos[5].position;
                  
                if (wayMapSpawnPercent >= 60)
                {
                    isWay = true;
                    instanceMonster(12);
                }

                    
                destroySpawner(12);
                isMoveMap = false;
            }
            else if (moveMapName == "StartMap1")
            {
                player.transform.position = moveMapPos[6].position;
                isMoveMap = false;
            }
            else if (moveMapName == "StartMap2")
            {
                player.transform.position = moveMapPos[7].position;
                isMoveMap = false;
            }
            else if (moveMapName == "StartMap3")
            {
                player.transform.position = moveMapPos[8].position;
                isMoveMap = false;
            }
            else if (moveMapName == "StartMap4")
            {
                player.transform.position = moveMapPos[9].position;
                isMoveMap = false;
            }
            else if (moveMapName == "StartMap5")
            {
                player.transform.position = moveMapPos[10].position;
                isMoveMap = false;
            }
            else if (moveMapName == "StartMap6")
            {
                player.transform.position = moveMapPos[11].position;
                isMoveMap = false;
            }
            else if (moveMapName == "BattleMap1")
            {
                player.transform.position = moveMapPos[12].position;
                isMoveMap = false;
                instanceMonster(1);
                destroySpawner(1);

            }
            else if (moveMapName == "BattleMap2")
            {
                player.transform.position = moveMapPos[13].position;
                isMoveMap = false;
                instanceMonster(2);
                destroySpawner(2);
            }
            else if (moveMapName == "BattleMap3")
            {
                player.transform.position = moveMapPos[14].position;
                isMoveMap = false;
                instanceMonster(3);
                destroySpawner(3);
            }
            else if (moveMapName == "BattleMap4")
            {
                player.transform.position = moveMapPos[15].position;
                isMoveMap = false;
                instanceMonster(4);
                destroySpawner(4);
            }
            else if (moveMapName == "BattleMap5")
            {
                player.transform.position = moveMapPos[16].position;
                isMoveMap = false;
                instanceMonster(5);
                destroySpawner(5);

            }
            else if (moveMapName == "BattleMap6")
            {
                player.transform.position = moveMapPos[17].position;
                isMoveMap = false;
                instanceMonster(6);
                destroySpawner(6);
            }
            else if (moveMapName == "WayMap1-2")
            {
                player.transform.position = moveMapPos[18].position;
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap2-2")
            {
                player.transform.position = moveMapPos[19].position;
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap3-2")
            {
                player.transform.position = moveMapPos[20].position;
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap4-2")
            {
                player.transform.position = moveMapPos[21].position;
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap5-2")
            {
                player.transform.position = moveMapPos[22].position;
                isMoveMap = false;
            }
            else if (moveMapName == "WayMap6-2")
            {
                player.transform.position = moveMapPos[23].position;
                isMoveMap = false;
            }
        }
        else
            EnemyCountUI(); // 전투중일때 몬스터UI


    }
    public void isGameClear(int minute, int seconds){
        coinText1.text = "" + currentCoine;
        Controllor_rkd.playerHp = 100;
        timeText1.text = "Time : "+minute+"분"+seconds+"초";
    }
    private void IsGameOver(int a = 0, int b = 0)
    {
        isGameOverImage.gameObject.SetActive(true);    // 게임오버 이미지 띄움.    
        coinText.text = "" + currentCoine;      // 현재 코인 보여줌.
        timeText.text = "Time : "+a+"분"+b+"초";
    }
    public void IsGameOverTimeText(int minute, int seconds){
        Debug.Log($"{minute}분 {seconds} 초");  
            IsGameOver(minute,seconds);
    }
    // }
        //for (int i = 0; i < check.Length; i++)
        //{
        //    if (check[i].isInstanceMonster)
        //    {

        //        for (int j = 0; j< 4; j++)
        //            Instantiate(enemy[Random.Range(0, 2)], spawnPoint[i].transform.position, Quaternion.identity);
        //        gunRotate.startGame = true;
        //    }
        //}

        //for (int i = 0; i < check.Length; i++)
        //{
        //    if (check[i].isInstanceMonster)
        //    {
        //        for (int j = 0; j < 4; j++)
        //            Instantiate(enemy[Random.Range(0, 2)], spawnPoint.position[j], Quaternion.identity);
        //        gunRotate.startGame = true;
        //    }
        //}

    public void instanceMonster(int waveCount) {
        //Debug.Log(check[0].isInstanceMonster);
            GunRotate.startGame = true;
            bgam.isBattle = false;
            bgam.PlayBGM(battleClip,1f);

            Color _minimap = minimap.color;
            _minimap.a = 1;
            minimap.color = _minimap;
            for(int i = 0; i<minimap1.Length; i++)
            {
                Color _minimap1 = minimap1[i].color;
                _minimap1.a = 1;
                minimap1[i].color = _minimap1;
            }
                
        if(isWay)
        {
           if (GameObject.Find("WaySpawnPoint" + waveCount.ToString()) != null)
            {
                Transform spawnPoint = GameObject.Find("WaySpawnPoint" + waveCount.ToString()).GetComponent<Transform>();
                for (int j = 0; j < WaymonsterCount; j++)
                {
                    WaychildSpawnPos[j] = spawnPoint.GetChild(j).transform;
                    Instantiate(enemy[UnityEngine.Random.Range(0, 2)], WaychildSpawnPos[j].position, Quaternion.identity);
                    //Debug.Log(spawnPoint[j].position);
                }
                isWay = false;
            }
            else
                return; 
        }
        else
        {
            if (GameObject.Find("SpawnPoint" + waveCount.ToString()) != null)
            {
                Transform spawnPoint = GameObject.Find("SpawnPoint" + waveCount.ToString()).GetComponent<Transform>();
                for (int j = 0; j < monsterCount; j++)
                {
                    childSpawnPos[j] = spawnPoint.GetChild(j).transform;
                    Instantiate(enemy[UnityEngine.Random.Range(0, 3)], childSpawnPos[j].position, Quaternion.identity);
                    //Debug.Log(spawnPoint[j].position);
                }
            }
            else
                return; 
        }
    
    }

    private void destroySpawner(int destroySpawnerCount)
    {
        GameObject spawnPoint = GameObject.Find("SpawnPoint" + destroySpawnerCount.ToString());
        Destroy(spawnPoint,1f);

    }


}
