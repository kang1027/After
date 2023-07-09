﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform Background;
    public RectTransform Cursor;
    private GameObject Character;

    public static int charAnim = 0;

    float radius = 0, speed = 7;
    bool isTouch = false;
    Vector3 movePosition = new Vector3(0, 0, 0);
    public static Vector2  value = new Vector2(0, 0);

    void Start()
    {
        radius = Background.rect.width * 0.5f;
        Character = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Debug.Log(value);
        if (isTouch)
            Character.transform.position += new Vector3(movePosition.x, movePosition.y, 0);
    }
    public void OnDrag(PointerEventData eventData)
    {
        value = eventData.position - (Vector2)Background.position; //방향벡터 계산

        value = Vector2.ClampMagnitude(value, radius); //커서 가두기 : value 크기
        Cursor.localPosition = value;

        value = value.normalized; //단위벡터 변환

        if(value != Vector2.zero)
        {
            if(value.x >= -0.7 && value.y >= 0.7)
            {
                charAnim = 1;
                //Debug.Log("상");
            }
            else if(value.x >= -0.7 && value.y <= -0.7)
            {
                charAnim = 2;
                //Debug.Log("하");
            }
            else if(value.x < -0.7 && value.y < 0.7)
            {
                charAnim = 3;
                //Debug.Log("좌");
            }
            else
            {
                charAnim = 4;
                //Debug.Log("우");
            }
        }
        else
            charAnim = 0;



        movePosition = new Vector3(value.x * speed * Time.deltaTime, value.y * speed * Time.deltaTime, 0f);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        Cursor.localPosition = new Vector3(0, 0, 0);
        value = Vector2.zero;
        movePosition = Vector3.zero;
    }
}

