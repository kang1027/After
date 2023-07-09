using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Bullet" || col.gameObject.tag=="EnemyBullet")
            Destroy(col.gameObject);
    }
}
