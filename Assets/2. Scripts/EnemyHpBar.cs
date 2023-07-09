using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    public Slider enemyHpBar;
    public Enemy_rkd enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemyHpBar.maxValue = enemy.monsterHp;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpBar.gameObject.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));

        enemyHpBar.value = enemy.monsterHp;
    }
}
