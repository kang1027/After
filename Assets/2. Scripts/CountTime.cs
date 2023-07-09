// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CountTime : MonoBehaviour
// {
//     public static float startTime;   
//     public static int currentTIme;

//     bool istimeCount;
//     GameManager gameManager;
//     // Start is called before the first frame update
//     void Start()
//     {
//         gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
//         StartCoroutine("a");
//         startTime = Time.time;
//         istimeCount = true;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(istimeCount)
//             currentTIme = (int)(Time.time-startTime);
//         if(!GameManager.isPlayingGame)
//         {
//             istimeCount = false;
//             int maxTime = currentTIme;
//             int minuteTime = 0;
//             while(minuteTime >= 60)
//             {
//                 minuteTime ++;
//                 maxTime -= 60;
//             }
//             gameManager.IsGameOverTimeText(minuteTime,maxTime);
//         }
//         if(GameManager.gameClear)
//         {
//             istimeCount = false;
//             int maxTime = currentTIme;
//             int minuteTime = 0;
//             while(minuteTime >= 60)
//             {
//                 minuteTime ++;
//                 maxTime -= 60;
//             }
//             gameManager.isGameClear(minuteTime,maxTime);
//         }
//     }
//     IEnumerator a(){
//         while(GameManager.isPlayingGame)
//         {
//             gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
//             yield return new WaitForSeconds(5.0f);
//         }
       
// }
// }


// /*
// private void GameOverUI()
//     {
//         if(timeCount)
//             currentTime = (int)(Time.time - startTime);
//         if (isPlay)
//         {
//             gameOverImage.gameObject.SetActive(false);
//         }
//         if (!isPlay)
//         {
//             timeCount = false;
//             int maxTime = currentTime;
//             int minuteTime = 0;
//             while(maxTime >= 60)
//             {
//                 minuteTime++;
//                 maxTime -= 60;
//             }
 

//             gameOverGemText.text = "젬 :     " + gem + " 개";
//             gameOverTimeText.text = ": " + minuteTime + "분 " +maxTime+"초";
//             gameOverImage.gameObject.SetActive(true);
//         }
//     }*/