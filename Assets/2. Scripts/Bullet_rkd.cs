using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_rkd : MonoBehaviour
{
    public float bulletSpeed = 10.0f;

    public GameObject ExplosionPrefab;
    public float DestroyExplosion = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }
    void Update()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag=="Wall"){
            var exp = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            Destroy(exp, DestroyExplosion);
            Destroy(gameObject);           
        }
    }

}
