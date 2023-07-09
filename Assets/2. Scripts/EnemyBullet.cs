using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 10.0f;

    public static Transform myT;

    public static bool isBounce;    // 총알 튕김 여부 판단.
    public ParticleSystem p1;
    // Start is called before the first frame update
    void Start()
    {
        myT = GetComponent<Transform>();
    }
    void Update()
    {
        if (isBounce)   // 튕길 수 있을 때.
            BounceBullet();
        else
            transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }
    private void DestroyBullet()
    {
        Destroy(this.gameObject, 1.5f);
        isBounce = false;
    }

    public static void BounceBullet()
    {
        myT.transform.position += -myT.up * 10.0f * Time.deltaTime; // 반대 방향으로 나감.
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag=="Wall")
        {
            var p2 =  Instantiate(p1, transform.position, Quaternion.identity);
            Destroy(p2, 2f);
            Destroy(this.gameObject, 0);
        }
    }
}
