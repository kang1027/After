using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Image AttackImg;
    public Sprite pickUpImg;
    private Sprite rollBackImg;

    public static bool isChange;
    // Start is called before the first frame update
    void Start()
    {
        AttackImg = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Image>();
        rollBackImg = AttackImg.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        { 
            if (AttackImg.sprite == pickUpImg)
                return;
            else
            {
                AttackImg.sprite = pickUpImg;
                isChange = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AttackImg.sprite = rollBackImg;
        isChange = false;
    }
}
