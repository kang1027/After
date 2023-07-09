using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controllor_rkd : MonoBehaviour
{

        public Sprite back;
        public Sprite foward;
        public Sprite right;
        public Sprite left;


    private Transform myT = null;
    private Animator myAnim;
    private SpriteRenderer mySr;


    public Button_A attackButton;   // 공격버튼

    public Transform weaponRotation;   // 무기 회전 Transform


    public static float playerHp = 8f; // hp


    private bool hitAble = true;        // 피격판정.

    public Enemy_rkd enemy;





    public int damage=0;


    // 무기들
    public Weapon_Gun gun;  
    public Weapon_Sword sword;
    public Weapon_Bow bow;
    public Weapon_Dart dart;

    // 바꿀 무기
    private GameObject changeWeapon;

    // 착용할 무기
    public GameObject[] weaponObj;
    //드랍되는 무기
    public GameObject[] weaponImg;

    GameObject currentWeaponImg;   // 현재 착용중인 무기사진
    // 무기번호
    public static int currentWeaponNum = 0;
    // Start is called before the first frame update
    Transform changePos;
    GameObject clone;
    // 바꿀 무기 이름
    public static string changeItemName = null;

    int engle = 0;  

    private AudioManager am;
    private AudioSource audioSource;
    public AudioClip walkClip;
    public AudioClip itemDrop;



    public Image a;
    public static bool aa;
    void Start()
    {
        myT = GetComponent<Transform>();
        myAnim = GetComponent<Animator>();
        mySr = GetComponent<SpriteRenderer>();
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();






        if(currentWeaponNum == 0)
        {    
            foreach (GameObject item1 in weaponObj)
            {
                if (item1.name == "Gun")
                {
                    item1.SetActive(true);
                }
                else
                    item1.SetActive(false);
            }
        }
        else if(currentWeaponNum == 1)
        {
            foreach (GameObject item1 in weaponObj)
                {
                    if (item1.name == "Sword")
                    {
                        item1.SetActive(true);
                    }
                    else
                        item1.SetActive(false);
                }
        }
        else if(currentWeaponNum == 2)
        {
            foreach (GameObject item1 in weaponObj)
                {
                    if (item1.name == "Bow")
                    {
                        item1.SetActive(true);

                    }
                    else
                        item1.SetActive(false);
                }
        }
    }
    public void aaaa(){
        if(aa)
        {

            Debug.Log("asdfeeeeeeee");
            if(currentWeaponNum == 0)
            {    
                foreach (GameObject item1 in weaponObj)
                {
                    if (item1.name == "Gun")
                    {
                        item1.SetActive(true);
                    }
                    else
                        item1.SetActive(false);
                }
            }
            else if(currentWeaponNum == 1)
            {
                foreach (GameObject item1 in weaponObj)
                    {
                        if (item1.name == "Sword")
                        {
                            item1.SetActive(true);
                        }
                        else
                            item1.SetActive(false);
                    }
            }
            else if(currentWeaponNum == 2)
            {
                foreach (GameObject item1 in weaponObj)
                    {
                        if (item1.name == "Bow")
                        {
                            item1.SetActive(true);

                        }
                        else
                            item1.SetActive(false);
                    }
            }
            a.gameObject.SetActive(false);

            aa = false;
        }
    }

    // Update is called once per frame
    void Update()
    {       
        if (GameManager.isPlayingGame)  // 게임이 실행중일때.
        {
            Move();
            Attack();
            GameOver();
            PickUp();
        }

            for(int i = 0; i<weaponImg.Length; i++)
            {      
                if(weaponObj[i].name == weaponImg[i].tag && weaponObj[i].activeSelf)
                {
                    currentWeaponImg = weaponImg[i];
                }
            }

        //Debug.Log($"소환가능?=>{PickUpItem.isChange},누름?=>{Input.GetKey(KeyCode.Z)}");     
    }

    public void PickUp()
    {
        if (PickUpItem.isChange && (Input.GetKeyDown(KeyCode.Z) || Button_A.isChangeButton /* 조이스틱 눌렀을 때 */))
        {
            if (changeItemName == "Gun")
            {
                Debug.Log("총");              
                currentWeaponNum = 0;
                foreach (GameObject item1 in weaponObj)
                {
                    if (item1.name == "Gun")
                    {
                        item1.SetActive(true);
                        ChangeItemImg();
                    }
                    else
                        item1.SetActive(false);
                }

            }
            else if (changeItemName == "Sword")
            {
                Debug.Log("검");
                currentWeaponNum = 1;
                foreach (GameObject item1 in weaponObj)
                {
                    if (item1.name == "Sword")
                    {
                        ChangeItemImg();
                        item1.SetActive(true);
                    }
                    else
                        item1.SetActive(false);
                }

            }
            else if (changeItemName == "Bow")
            {
                Debug.Log("활");
                currentWeaponNum = 2;

                foreach (GameObject item1 in weaponObj)
                {
                    if (item1.name == "Bow")
                    {
                        ChangeItemImg();
                        item1.SetActive(true);

                    }
                    else
                        item1.SetActive(false);
                }
            }
            else if (changeItemName == "Dart")
            {
                Debug.Log("표창");
                currentWeaponNum = 3;
                foreach (GameObject item1 in weaponObj)
                {
                    if (item1.name == "Dart")
                    {
                        ChangeItemImg();
                        item1.SetActive(true);
                    }
                    else
                        item1.SetActive(false);
                }
            }
            //foreach(GameObject item in a)
            //{

            //    if (item.tag == "Gun")
            //    {
            //        Debug.Log("총줍기");
            //    }
            //    else if (item.tag == "Arrow")
            //    {
            //        Debug.Log("활줍기");

            //    }
            //    else if (item.tag == "Sword")
            //    {
            //        Debug.Log("검줍기");
            //    }
            //    else if (item.tag == "Dart")
            //    {
            //        Debug.Log("표창줍기");
            //    }
            //}
            Button_A.isChangeButton = false;
        }
    }
    public void ChangeItemImg()
    {
        audioSource.PlayOneShot(itemDrop);
        changePos = changeWeapon.transform;
        clone = Instantiate(currentWeaponImg, changePos.position, Quaternion.identity);
        Destroy(changeWeapon, 0);
    }
    public void addItemList(GameObject item)
    {
        changeWeapon = item;
    }
    private void GameOver()
    {
        if (playerHp <= 0)
        {
            GameManager.isPlayingGame = false;  // 게임 끝냄.
            myAnim.StopPlayback();          // 애니메이션 중지.
        }
    }

    private void Attack()
    {
        if (attackButton.aTouch && !attackButton.isShoot && !PickUpItem.isChange && !Potal.isMove)      // 공격버튼 감지했을 때.
        {
            
            if (currentWeaponNum == 0)
                gun.JoystickShoot();
             if (currentWeaponNum == 1)
                sword.JoyStickAttack();
            if (currentWeaponNum == 2)
                bow.JoystickShoot();
        }
        
        if (!PickUpItem.isChange)    // 키보드
        {
            if (currentWeaponNum == 0 && !attackButton.isShoot)
                gun.Shoot();
            else if (currentWeaponNum == 1)
                sword.Attack();
            else if (currentWeaponNum == 2)
                bow.Shoot();
        }
    }
    private void OnDrawGizmos() // 근접공격 범위 기즈모 생성.
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(sword.attackPos.position, sword.boxSize);
    }

    private void Move()
    {
            float xM = Input.GetAxisRaw("Horizontal") * 7.0f * Time.deltaTime;  
            float yM = Input.GetAxisRaw("Vertical") * 7.0f * Time.deltaTime;  
            Vector3 movePos = new Vector3(xM, yM, 0);   
        myT.Translate(xM, yM, 0);               // 컴퓨터로 할 경우의 이동, 조이스틱으로 바꿈.
    
        if (GunRotate.isAttack)
            weaponRotation.localScale = new Vector3(1, 1, 0);

        if (movePos != new Vector3(0, 0, 0) || JoyStick.value != Vector2.zero)    // 정지해 있을 경우 상하좌우에 맞춰 무기 돌림.
        {
            am.AM(walkClip);
            myAnim.enabled = true;
            if (Input.GetKey(KeyCode.W) || JoyStick.charAnim == 1)
            {
                engle = 1;
                myAnim.SetBool("IsRight", false);   // 좌,우 애니메이션 시간 남을 때 flip을 돌리는 걸로 하나의 애니메이션만 사용.
                myAnim.SetBool("IsLeft", false);
                myAnim.SetBool("IsForward", false);
                myAnim.SetBool("IsBack", true);
                if (!GunRotate.isAttack && !Weapon_Sword.isSwordAttack)
                {
                    weaponRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 90f));
                }
            }
            else if (Input.GetKey(KeyCode.S) || JoyStick.charAnim == 2)
            {
                engle = 2;
                myAnim.SetBool("IsRight", false);
                myAnim.SetBool("IsLeft", false);
                myAnim.SetBool("IsBack", false);
                myAnim.SetBool("IsForward", true);
                if (!GunRotate.isAttack && !Weapon_Sword.isSwordAttack)
                    weaponRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 270f));
            }
            else if (Input.GetKey(KeyCode.D) || JoyStick.charAnim == 4)
            {          
                engle = 3;      
                myAnim.SetBool("IsLeft", false);
                myAnim.SetBool("IsBack", false);
                myAnim.SetBool("IsForward", false);
                myAnim.SetBool("IsRight", true);
                if (!GunRotate.isAttack && !Weapon_Sword.isSwordAttack)
                {
                    weaponRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 0f));
                    weaponRotation.localScale = new Vector3(1, 1, 0);
                }
            }
            else if (Input.GetKey(KeyCode.A) || JoyStick.charAnim == 3)
            {
                engle = 4;
                myAnim.SetBool("IsRight", false);
                myAnim.SetBool("IsBack", false);
                myAnim.SetBool("IsForward", false);
                myAnim.SetBool("IsLeft", true);
                if (!GunRotate.isAttack && !Weapon_Sword.isSwordAttack)
                {
                    weaponRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 180f));
                    weaponRotation.localScale = new Vector3(1, -1, 0);
                }
            }
        }
        else
        {
                myAnim.SetBool("IsRight", false);
                myAnim.SetBool("IsLeft", false);
                myAnim.SetBool("IsBack", false);
                myAnim.SetBool("IsForward", false);
                            myAnim.enabled = false;
        
                if(engle == 1)
                {
                    weaponRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 90f));
                    mySr.sprite = back;
                }
                else if(engle == 2)
                {           
                    weaponRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 270f));
                    mySr.sprite = foward;
                }
                else if(engle == 3)
                {
                    weaponRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 0f));
                    weaponRotation.localScale = new Vector3(1, 1, 0);
                    mySr.sprite = right;
                }
                else if(engle == 4){
                    weaponRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 180f));
                    weaponRotation.localScale = new Vector3(1, -1, 0);
                    mySr.sprite = left;
                }
            
        }

        

    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag=="EnemyBullet" || collision.gameObject.tag=="Enemy") && hitAble)   // 공격 받았을 때
        {
            hitAble = false;    // 잠시 공격 회피.
            //Debug.Log(playerHp);
            playerHp -= Enemy_rkd.monsterDamage;
            Invoke("HitDealy", 2f);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && hitAble)
        {
            hitAble = false;
            //Debug.Log(playerHp);
            playerHp -= Enemy_rkd.monsterDamage;
            Invoke("HitDealy", 2f);
        }
    }
    private void HitDealy()
    {
        hitAble = true; // 다시 공격 맞음.
    }
    //private void PlayerRotation()
    //{
    //    Vector3 dir = enemyPosi.position - myT.position;
    //    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

    //    myT.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //}



}
