using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Character", menuName = "Character", order = 1)]
public class Player_Character : ScriptableObject
{
    public int Range;
    public int Max_Health;
    public int Damage;
}
