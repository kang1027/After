using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_A : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool aTouch;
    public Button_A value;   
    public bool isShoot;
    private bool changeCollTime;
    public Controllor_rkd player;

    public static bool isChangeButton;
    public bool isMoveMap;

    public void OnPointerDown(PointerEventData eventData)
    {
        isMoveMap=true;
        if(PickUpItem.isChange)
            isChangeButton = true;

        value.aTouch = true;
        if (PickUpItem.isChange && changeCollTime)
        {
            changeCollTime = false;
            Invoke("ItemChangeCoolTime",0.5f);
        }

    }
    private void ItemChangeCoolTime()
    {
        changeCollTime = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isMoveMap=false;

        value.aTouch = false;
    }

}
