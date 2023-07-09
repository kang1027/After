//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WeaponChange : MonoBehaviour
//{
//    // 무기들
//    public Weapon_Gun gun;
//    public Weapon_Sword sword;
//    public Weapon_Bow bow;
//    public Weapon_Dart dart;

//    // 바꿀 무기
//    private GameObject changeWeapon;

//    // 착용할 무기
//    public GameObject[] weaponObj;
//    //드랍되는 무기
//    public GameObject[] weaponImg;

//    GameObject currentWeaponImg;   // 현재 착용중인 무기사진
//    // 무기번호
//    private int currentWeaponNum = 1;

//    Transform changePos;
//    GameObject clone;
//    // 바꿀 무기 이름
//    public static string changeItemName = null;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Debug.Log($"현재 무기 사진 =>{currentWeaponImg}");
//        for (int i = 0; i < weaponImg.Length; i++)
//        {
//            if (weaponObj[i].name == weaponImg[i].tag && weaponObj[i].activeSelf)
//            {
//                currentWeaponImg = weaponImg[i];
//            }
//        }
//    }

//    public void PickUp()
//    {
//        if (PickUpItem.isChange && Input.GetKeyDown(KeyCode.Z))
//        {
//            if (changeItemName == "Gun")
//            {
//                Debug.Log("총");
//                currentWeaponNum = 0;
//                foreach (GameObject item1 in weaponObj)
//                {
//                    if (item1.name == "Gun")
//                    {
//                        item1.SetActive(true);
//                        ChangeItemImg();
//                    }
//                    else
//                        item1.SetActive(false);
//                }

//            }
//            else if (changeItemName == "Sword")
//            {
//                Debug.Log("검");
//                currentWeaponNum = 1;
//                foreach (GameObject item1 in weaponObj)
//                {
//                    if (item1.name == "Sword")
//                    {
//                        ChangeItemImg();
//                        item1.SetActive(true);
//                    }
//                    else
//                        item1.SetActive(false);
//                }

//            }
//            else if (changeItemName == "Bow")
//            {
//                Debug.Log("활");
//                currentWeaponNum = 2;

//                foreach (GameObject item1 in weaponObj)
//                {
//                    if (item1.name == "Bow")
//                    {
//                        ChangeItemImg();
//                        item1.SetActive(true);

//                    }
//                    else
//                        item1.SetActive(false);
//                }
//            }
//            else if (changeItemName == "Dart")
//            {
//                Debug.Log("표창");
//                currentWeaponNum = 3;
//                foreach (GameObject item1 in weaponObj)
//                {
//                    if (item1.name == "Dart")
//                    {
//                        ChangeItemImg();
//                        item1.SetActive(true);
//                    }
//                    else
//                        item1.SetActive(false);
//                }
//            }
//            //foreach(GameObject item in a)
//            //{

//            //    if (item.tag == "Gun")
//            //    {
//            //        Debug.Log("총줍기");
//            //    }
//            //    else if (item.tag == "Arrow")
//            //    {
//            //        Debug.Log("활줍기");

//            //    }
//            //    else if (item.tag == "Sword")
//            //    {
//            //        Debug.Log("검줍기");
//            //    }
//            //    else if (item.tag == "Dart")
//            //    {
//            //        Debug.Log("표창줍기");
//            //    }
//            //}
//        }
//    }
//    private void ChangeItemImg()
//    {
//        changePos = changeWeapon.transform;
//        clone = Instantiate(currentWeaponImg, changePos.position, Quaternion.identity);
//        Destroy(changeWeapon, 0);

//    }
//    public void addItemList(GameObject item)
//    {
//        changeWeapon = item;
//    }
//}
