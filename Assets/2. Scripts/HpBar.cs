using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{

    public Slider hpBar;
    // Start is called before the first frame update
    void Start()
    {
        hpBar.maxValue = 8;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.gameObject.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0,0.8f,0));
        hpBar.value = Controllor_rkd.playerHp;

    }
}
