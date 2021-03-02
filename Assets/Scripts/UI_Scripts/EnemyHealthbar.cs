using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Slider healthBar;
    public GameObject enemy;
    private int currentHP;

    public void Awake()
    {
        currentHP = enemy.GetComponent<Enemy_Manager>().Current_Health;
        healthBar = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHP;
        Debug.Log("I am going down");
    }


}
