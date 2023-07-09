// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class RobbyPlayer : MonoBehaviour
// {
//     // 로비에서 플레이어의 이동.

//     private Transform myT = null;
//     private Animator myAnim;
//     private SpriteRenderer mySr;


//     public GameObject bullt;
//     public Transform shootPosition;
//     public GameObject gun;
//     public ParticleSystem gunPt;
//     public Transform gunRotation;
//     public Button_A attackButton;


//     public Transform attackPos;
//     public Vector2 boxSize;

//     // Start is called before the first frame update
//     void Start()
//     {
//         myT = GetComponent<Transform>();
//         myAnim = GetComponent<Animator>();
//         mySr = GetComponent<SpriteRenderer>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//             Move();
//             Attack();
//     }


//     private void Attack()
//     {
//         if (attackButton.aTouch && !attackButton.isShoot)
//         {     // 공격버튼 감지했을 떄
//             StartCoroutine("GunShoot");
//         }
//         if (Input.GetKeyDown(KeyCode.Q))
//         {
//             //Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPos.position, boxSize, 0);
//             //foreach (Collider2D collider in collider2Ds)
//             //{
//             //    if (collider.tag == "Enemy")
//             //    {
//             //        collider.GetComponent<Enemy_rkd>().Damaged(10f);
//             //        break;
//             //    }
//             //}
//             Instantiate(bullt, shootPosition.position, gun.transform.rotation);
//             gunPt.Play();
//         }
//     }

//     //private void OnDrawGizmos()
//     //{
//     //    Gizmos.color = Color.blue;
//     //    Gizmos.DrawWireCube(attackPos.position, boxSize);
//     //}  // 근접공격 범위 기즈모 생성.

//     private void Move()
//     {
//         float xM = Input.GetAxisRaw("Horizontal") * 7.0f * Time.deltaTime;
//         float yM = Input.GetAxisRaw("Vertical") * 7.0f * Time.deltaTime;
//         Vector3 movePos = new Vector3(xM, yM, 0);
//         myT.Translate(xM, yM, 0);
//         if (movePos != new Vector3(0, 0, 0))
//         {
//             if (Input.GetKey(KeyCode.W))
//             {

//                 myAnim.SetBool("IsRight", false);
//                 myAnim.SetBool("IsLeft", false);
//                 myAnim.SetBool("IsForward", false);
//                 myAnim.SetBool("IsBack", true);
//                     gunRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 90f));
//             }
//             else if (Input.GetKey(KeyCode.S))
//             {

//                 myAnim.SetBool("IsRight", false);
//                 myAnim.SetBool("IsLeft", false);
//                 myAnim.SetBool("IsBack", false);
//                 myAnim.SetBool("IsForward", true);
//                     gunRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, -90f));
//             }
//             else if (Input.GetKey(KeyCode.D))
//             {
//                 myAnim.SetBool("IsLeft", false);
//                 myAnim.SetBool("IsBack", false);
//                 myAnim.SetBool("IsForward", false);
//                 myAnim.SetBool("IsRight", true);
//                     gunRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 0f));
//             }
//             else if (Input.GetKey(KeyCode.A))
//             {

//                 myAnim.SetBool("IsRight", false);
//                 myAnim.SetBool("IsBack", false);
//                 myAnim.SetBool("IsForward", false);
//                 myAnim.SetBool("IsLeft", true);
//                     gunRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, 180f));
//             }
//         }
//         else
//         {
//             myAnim.SetBool("IsRight", false);
//             myAnim.SetBool("IsLeft", false);
//             myAnim.SetBool("IsBack", false);
//             myAnim.SetBool("IsForward", false);
//             gunRotation.localRotation = Quaternion.Euler(new Vector3(0, 0, -90f));

//         }
//     }

//     IEnumerator GunShoot()
//     {
//         Instantiate(bullt, shootPosition.position, gun.transform.rotation);
//         gunPt.Play();
//         attackButton.isShoot = true;
//         yield return new WaitForSeconds(0.2f);
//         attackButton.isShoot = false;
//     }

    
//     //private void PlayerRotation()
//     //{
//     //    Vector3 dir = enemyPosi.position - myT.position;
//     //    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

//     //    myT.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
//     //}



// }
