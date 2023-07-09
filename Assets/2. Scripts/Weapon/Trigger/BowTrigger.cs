using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTrigger : MonoBehaviour
{
    Controllor_rkd player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controllor_rkd>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("ㅁㄴㅇㄹㄴㅁㅇㄹ");
            Controllor_rkd.changeItemName = "Bow";
            player.addItemList(gameObject);
        }
    }
}
