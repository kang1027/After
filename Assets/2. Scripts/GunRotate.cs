using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    private Transform myT;

    private Transform enemyPosi;    // 적 위치 transform 받음

    private Vector3 dir = Vector3.zero; // 적과 나의 위치 사이의 값.
    private float angle;    // 회전해야할 각도
    public float attackDistance = 0.0f;

    float dist;

    public static bool isAttack;
    public static bool startGame = false;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        myT = GetComponent<Transform>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //InvokeRepeating("getClosestEnemy", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //GunRotation();

        //if (!enemyPosi)
        //    Debug.DrawLine(myT.position, enemyPosi.position, Color.yellow);

            if (startGame)
            {
                getClosestEnemy();

                if (enemyPosi == null)   // 추적할 몬스터가 존재하지 않을 경우.
                {
                    startGame =false;
                    gm.isChange = false;
                    gm.ChangeBGM();
                }
                else
                {
                    float dis = Vector2.Distance(myT.position, enemyPosi.position);
                    if (dis < attackDistance && !Weapon_Sword.isSwordAttack)
                    {
                        isAttack = true;
                        dir = enemyPosi.position - myT.position;    // dir에 적과 나 사이의 거리 저장
                        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;  // atan(아크탄젠트)2함수를 써서 적과 나의 각도를 구하고 그 값을 반환한다. rad2deg로 atan2의 반환값인 라디안을 상수로 바꿔준다.
                        myT.rotation = Quaternion.AngleAxis(angle, Vector3.forward);    // angleaxis를 이용해 각도를 회전시킨다.
                    }
                    else
                        isAttack = false;
                }
            }
            else
            {
                isAttack = false;
                return;
            }
                
        

    }
    private void getClosestEnemy()
    {
            GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("Enemy"); // 태그를 이용해 Enemy를 배열에 넣음.
            float closestDistSqr = Mathf.Infinity;      //가장 가까운 위치 제한x
            Transform closestEnemy = null;              // 가장 가까운 적
            foreach (GameObject taggedEnemy in taggedEnemys) // foreach 반복문 돌림
            {
                Vector3 objectPos = taggedEnemy.transform.position; // objectPos에 배열에 적 위치 받음.
                dist = (objectPos - transform.position).sqrMagnitude;   // 적 위치에서 내 위치를 뺀 값을 sqrMagnitude로 2차원 함수값으로 바꿔줌. 

                if (dist < closestDistSqr)      // dist가 closesDisSqr보다 작을 때
                {
                    closestDistSqr = dist;  // closestDistSqr에 dist를 넣음.
                    closestEnemy = taggedEnemy.transform;   // closestEnemy에 현재 배열 몬스터를 넣음.
                }
            }
            enemyPosi = closestEnemy;       
    }

    //private void GunRotation()
    //{

    //    dir = enemyPosi.position - myT.position;
    //    angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //    myT.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    //    if (angle >= 90 || angle <= -90)
    //        Player.flipX = false;
    //    else
    //        Player.flipX = true;

        

    //}
}
