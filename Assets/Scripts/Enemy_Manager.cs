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
    public int Seen_By;
    private GameObject Game_Manager;

    //function to reverse if it's this enemy's turn or not
    public void End_turn()
    {
        isyourturn = !isyourturn;
    }

    //sets stats and defines some stuff
    private void Start()
    {
        Max_Health = 20;
        Current_Health = Max_Health;
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        Seen_By = 0;
    }

    private void Update()
    {
        //detects if it's dead and removes it if it is
        if (Current_Health <= 0)
        {
            Seen_By = 0;
            Destroy(gameObject);
            Debug.Log("Dead");
        }

        //turns the enemy visible if the player chars can see it
        if (Seen_By > 0)
        {
            if (gameObject.GetComponent<Renderer>().enabled == false)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
        else
        {
            if (gameObject.GetComponent<Renderer>().enabled == true)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}

