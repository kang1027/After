using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerTrace : MonoBehaviour
{
    public Transform player;
    private Transform myT;
    public Transform headPos;   // 공격 방향
    public float monsterSpeed = 0.01f;
    private bool isTraceRange;  // 추적 가능 여부 판단.
    public float traceDistance = 0.0f;  // 추적 사거리.
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myT = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.isPlayingGame)   // 게임 시작중일 때.
        {
            float distance = Vector2.Distance(player.position, myT.position);   // Player와 나 사이의 거리를 distance에 넣음.
            if (traceDistance > distance)  // 추적 사거리가 distance보다 멀 때
                isTraceRange = true;
            else
                isTraceRange = false;
            if (isTraceRange)
            {
                Vector2 direction = new Vector2(        // Player와 나 사이의 거리.
                transform.position.x - player.position.x,
                transform.position.y - player.position.y
                );


                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;    
                Quaternion angleAxis = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
                // Quaternion rotation = Quaternion.Slerp(headPos.rotation, angleAxis, 10f * Time.deltaTime);
                // headPos.rotation = rotation;                                                                    //headPos 회전.
                myT.position = Vector2.MoveTowards(myT.position, player.position, monsterSpeed * Time.deltaTime);
                Console.WriteLine("sex");
            }
        }
    }
}
