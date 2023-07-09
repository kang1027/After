using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrigger : MonoBehaviour
{
    Controllor_rkd player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controllor_rkd>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Controllor_rkd.changeItemName = "Dart";

            player.addItemList(gameObject);

        }
    }
}
