﻿using System.Collections;
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
    
    public void End_turn()
    {
        isyourturn =! isyourturn;
    }

    private void Start()
    {
        Damage = 10;
        Range = 5;
    }
}

