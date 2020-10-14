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

    public void End_turn()
    {
        isyourturn = !isyourturn;
    }

    private void Start()
    {
        Max_Health = 20;
        Current_Health = Max_Health;
    }
}
