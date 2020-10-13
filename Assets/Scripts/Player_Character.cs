using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Character : MonoBehaviour
{
    public int Range;
    public int Max_Health;
    public int Damage;
    public int initiative;
    public bool isyourturn;
    
    public void End_turn()
    {
        isyourturn =! isyourturn;
}
}

