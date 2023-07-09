using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyBullet; // Enemy의 총알
    public Transform shootPosition; // 총알을 발사할 위치
    public Transform gun;           // 발사할 총
    public Transform player;    // 추적할 Player
    public Transform gunPos;    // 회전할 중심축.

    private Transform myT;      // 내 transform 컴포넌트

    private Vector3 dir = Vector3.zero;

    private float angle;
    public float movePower = 1.0f;  // 자동으로 움직일 때 이동속도
    public float attackDistance = 5.0f;     // 공격 사거리
    public float shootDealy = 2.0f;     //공격 딜레이
    

    private int movementFlag = 0;   // 0~4의 무작위값을 받음

    private bool isShootRange;       // 공격이 가능 범위일 때 true를 나타내느 변수
    private bool isShoot;       // 공격 했을 때 딜레이를 주기 위한 변수


    private AudioSource audioSource;
    public AudioClip attackClip;
    void Start()
    {
        
        StartCoroutine("ChangeMovement");
        myT = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  // Player 태그를 가진 오브젝트의 트랜스폼을 줌
        audioSource = GetComponent<AudioSource>();
         transform.localScale = new Vector3(1,1,1);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(GameManager.isPlayingGame)
        {
            float distance = Vector2.Distance(player.position, myT.position);   // Player와 나 사이의 거리를 distance에 넣음.
            if (attackDistance > distance)  // 공격 사거리가 distance보다 멀 때
                isShootRange = true;
            else
                isShootRange = false;
            
            Move();
        }

    }

    private void Move()
    {
            if (isShootRange)   // 공격이 가능할 때
            {

                Vector2 direction = new Vector2(        // 적과 나 사이의 거리.
                    transform.position.x - player.position.x,
                    transform.position.y - player.position.y
                );

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;    // 적과 나 사이의 각도 구함.
                Quaternion angleAxis = Quaternion.AngleAxis(angle + 90f, Vector3.forward);  // 회전각 구함.
                Quaternion rotation = Quaternion.Slerp(gunPos.rotation, angleAxis, 100f * Time.deltaTime);  // slerp로 자연스러운 회전 구현.
                gunPos.rotation = rotation;                                                                 // 회전.
                //Debug.Log("공격가능");
                if (!isShoot)        // 현재 슛이 안되고 있을 때
                {
                    StartCoroutine("Shoot");    // Shoot 코루틴 실행
                }
            }
            else       // 공격 불가할 때
            {
                Vector3 moveVelocity = Vector3.zero;    // moveVelocity 초기화

                if (movementFlag == 1)
                {
                    moveVelocity = Vector3.left;    // 왼쪽 방향
                    transform.localScale = new Vector3(1, 1, 1);   // localScale 초기화.
                }
                else if (movementFlag == 2)
                {
                    moveVelocity = Vector3.right;   // 오른쪽 방향
                    transform.localScale = new Vector3(1, 1, 1); // localScale 초기화.
                }
                else if (movementFlag == 3)
                {
                    moveVelocity = Vector3.up;  // 위 방향
                    transform.localScale = new Vector3(1, 1, 1); // localScale 초기화.
                }
                else if (movementFlag == 4)
                {
                    moveVelocity = Vector3.down;    // 아래 방향
                    transform.localScale = new Vector3(1, 1, 1); // localScale 초기화.
                }
                transform.position += moveVelocity * movePower * Time.deltaTime;    // 이동
            }
        
        
    }


     IEnumerator ChangeMovement()       // 랜덤 이동 코루틴
    {
        movementFlag = Random.Range(0, 5);  // 0~4의 값을 랜덤으로 생성.
        //Debug.Log(movementFlag);
        if (movementFlag == 0)
            Debug.Log("애니메이션 중지");  // 멈출 땐 애니메이션 스탑
        else
            Debug.Log("애니베이션 시작");  // 멈추지 않을 때 애니메이션 재생
        yield return new WaitForSeconds(1.5f);  // 1.5초 대기시간

        StartCoroutine("ChangeMovement");   // 코루틴 재시작   
    }

    IEnumerator Shoot()
    {
        EnemyBullet.isBounce = false;   // 총 튕기기 false.
        Instantiate(enemyBullet, shootPosition.position, Quaternion.Euler(gun.rotation.eulerAngles.x,gun.rotation.eulerAngles.y,gun.rotation.eulerAngles.z-90f)); // 총알 생성    
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(attackClip);
        isShoot = true;
        yield return new WaitForSeconds(shootDealy);        // shootDealy만큼 대기
        isShoot = false;
    }
}
