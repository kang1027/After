using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Sword : MonoBehaviour
{
    public Transform attackPos; // 공격 위치
    public Vector2 boxSize;     // 공격 범위

    public GameObject weapon;
    
    public static bool isSwordAttack;

    public float delay = 1.0f;
    private float currentTime = 0;
    // public ParticleSystem p1;
    // public Transform p1Pos;

    private AudioSource audioSource;
    public AudioClip shoot;

    public Button_A attackButton;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    void Update(){
//        Debug.Log(weapon.transform.localRotation.eulerAngles.z+50); 
    }
    public void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(delay <  Time.time-currentTime)
            {
                currentTime = Time.time;
                audioSource.PlayOneShot(shoot);
            StartCoroutine("SwordRotate");
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPos.position, boxSize, 0); // 공격 범위.
            // 50 ~ -50 각도로 검 회전
            foreach (Collider2D collider in collider2Ds)
            {
                //Debug.Log(collider.gameObject.tag);
                if (collider.tag == "Enemy")        // 범위 안에 적이 있을 때
                {
                    collider.GetComponent<Enemy_rkd>().Damaged(25f);
                }

                if (collider.tag == "EnemyBullet")  // 범위 안에 적의 총알이 있을 때
                {
                    Destroy(collider.gameObject, 0);
                    //EnemyBullet.isBounce = true;    // 튕기게 하는 조건 true
                }
            }
            }
            //Instantiate(p1, p1Pos.position, weapon.transform.rotation);

        }
        // else if(Input.GetKeyDown(KeyCode.E))
        // {
        //     Quaternion a = weapon.transform.localRotation;
        //     a.eulerAngles = new Vector3(0,0,weapon.transform.localRotation.eulerAngles.z-50);
        //     weapon.transform.localRotation = a;
        // }

       

    }


    public void JoyStickAttack(){
        attackButton.isShoot = true;


        if(delay <  Time.time-currentTime)
            {
                currentTime = Time.time;
                audioSource.PlayOneShot(shoot);
            StartCoroutine("SwordRotate");
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPos.position, boxSize, 0); // 공격 범위.
            // 50 ~ -50 각도로 검 회전
            foreach (Collider2D collider in collider2Ds)
            {
                //Debug.Log(collider.gameObject.tag);
                if (collider.tag == "Enemy")        // 범위 안에 적이 있을 때
                {
                    collider.GetComponent<Enemy_rkd>().Damaged(25f);
                }

                if (collider.tag == "EnemyBullet")  // 범위 안에 적의 총알이 있을 때
                {
                    Destroy(collider.gameObject, 0);
                    //EnemyBullet.isBounce = true;    // 튕기게 하는 조건 true
                }
            }
            }
            else
            attackButton.isShoot = false;

    }

     IEnumerator SwordRotate(){
            isSwordAttack = true;
            Quaternion a = weapon.transform.localRotation;
            a.eulerAngles = new Vector3(0,0,weapon.transform.localRotation.eulerAngles.z+90);
            weapon.transform.localRotation = a;

            for(int i = 0; i<10; i++)
            {
                a.eulerAngles = new Vector3(0,0,weapon.transform.localRotation.eulerAngles.z-16);
                weapon.transform.localRotation = a;
                yield return new WaitForSeconds(0.007f);

            }
            isSwordAttack = false;
            attackButton.isShoot = false;

            yield return null;
        }


}
