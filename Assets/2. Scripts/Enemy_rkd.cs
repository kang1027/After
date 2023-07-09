using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_rkd : MonoBehaviour
{

    private Transform myT = null;
    private Rigidbody myR = null;

    public Transform[] dropPos; // 아이템 떯어뜨릴 위치배열.

    public List<GameObject> dropItem = new List<GameObject>();

    private Controllor_rkd player;

    public int monster2 = 0;

    public float monsterHp;
    public static float monsterDamage = 1f;
    [SerializeField]
    public GameObject weaponItem;

    private bool isDead;

    private Weapon_Bow bow;

    public ParticleSystem p1;
    public ParticleSystem dropPs;
    public bool isDropPs;

    private AudioManager audioManager;
    public AudioClip deathClip;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        myT = GetComponent<Transform>();
        myR = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controllor_rkd>();

        if (monster2 == 0)
            monsterHp = 60.0f;
        else if(monster2 == 1)
            monsterHp = 50.0f;
        else if(monster2 == 2)
            monsterHp = 300;
    }

    void Update()
    {
        if(transform.position.x < player.transform.position.x)
        {
            sr.flipX = true;
        }
        else
            sr.flipX = false;
        if(GameObject.FindGameObjectWithTag("Bow1"))
             bow = GameObject.FindGameObjectWithTag("Bow1").GetComponent<Weapon_Bow>();
    }
    public void Damaged(float damage)
    {
        monsterHp -= damage;    // 피격 시 hp 깎임.
        if(monsterHp <= 0)
        {
            isDead = true;
            monsterDead();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag=="EnemyBullet" && GameManager.isPlayingGame)   // 총 피격 시
        {
            EnemyBullet.isBounce = false;  // 총 튕기기 false (지금은 지우는거로 함.
            monsterHp -= 15;
            if(monsterHp<=0)
            {
                isDead = true;
                monsterDead();        
            }
            Destroy(collision.gameObject, 0.01f);
        }
        if(collision.gameObject.tag=="Arrow" && GameManager.isPlayingGame)
        {
            monsterHp -= bow.bowDamage;
            if (monsterHp <= 0)
            {
                isDead = true;
                monsterDead();
            }
            Destroy(collision.gameObject, 0.01f);

        }
    }

    private void monsterDead()
    {
        
        audioManager.MonsterDeath(deathClip);
        var p2 =  Instantiate(p1, transform.position, Quaternion.identity);
         Destroy(p2, 2f);
        float dropItemPercent = Random.Range(1, 101);// 드랍퍼센트
        int dropItemPos = Random.Range(1, 4);       // 아이템 떯어뜨릴 위치
        int itemShuple = Random.Range(0, dropItem.Count);  // 아이템 셔플

        //Debug.Log($"dropPercent=>{dropItemPercent}");

        //    Debug.Log($"dropItemPosRange=>{dropItemPos}, {itemShuple}");
        Destroy(this.gameObject, 0f);
        GameManager.currentCoine += Random.Range(5, 11);    // 코인 드랍.
        if(dropItemPercent >= 85)
        {
            Instantiate(dropItem[itemShuple], dropPos[dropItemPos].position, Quaternion.identity);
            var dropPs1 = Instantiate(dropPs, dropPos[dropItemPos].position, Quaternion.identity);
            Destroy(dropPs1,3f);
        }
       // player.addItemList(Instantiate(dropItem[itemShuple], dropPos[dropItemPos].position, Quaternion.identity));
                //player.addItemList(weaponItem);
            //for (int i = 0; i <player.a.Count; i++)
            //{
            //    Debug.Log("i =  " + i + "값 = " +player.a[i]);
            //    Debug.Log("반복횟수"+player.a.Count);
            //}
        
    }

}
