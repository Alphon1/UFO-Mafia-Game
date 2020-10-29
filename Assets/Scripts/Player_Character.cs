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
    public int Action_Points;
    [SerializeField]
    private int Max_Action_Points;

    //if it was the player's turn, now it isn't and vice versa
    public void End_turn()
    {
        isyourturn = !isyourturn;
        if (isyourturn)
        {
            Action_Points = Max_Action_Points;
        }
    }
}

