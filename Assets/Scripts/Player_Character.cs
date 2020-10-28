using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Character : MonoBehaviour
{
    public int Range;
    private int Max_Health;
    public int Damage;
    private int initiative;
    private int Current_Health;
    public bool isyourturn;

    //if it was the player's turn, now it isn't and vice versa
    public void End_turn()
    {
        isyourturn =! isyourturn;
    }

    private void Start()
    {
        //sets some dummy stats
        Damage = 10;
        Range = 5;
    }
}

