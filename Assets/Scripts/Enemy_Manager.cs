using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    private int Range;
    private int Max_Health;
    private int Damage;
    private int initiative;
    public int Current_Health;
    public bool isyourturn;
    private GameObject Game_Manager;


    public void End_turn()
    {
        isyourturn = !isyourturn;
    }

    private void Start()
    {
        Max_Health = 20;
        Current_Health = Max_Health;
        Game_Manager = GameObject.FindWithTag("Game_Manager");

    }

    private void Update()
    {
        if (Current_Health <= 0)
        {
            Game_Manager.GetComponent<Game_Manager>().Visible_Enemies.Remove(gameObject);
            Game_Manager.GetComponent<Game_Manager>().Enemy_List.Remove(gameObject);
            foreach (GameObject Player_Char in GameObject.FindGameObjectsWithTag("Tonies"))
            {
                Player_Char.GetComponentInChildren<Player_Vision>().Nearby_Enemies.Remove(gameObject);
            }
            Destroy(gameObject);
            Debug.Log("Dead");
        }
    }
}

