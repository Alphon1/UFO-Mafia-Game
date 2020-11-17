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
    [SerializeField]
    private GameObject Mov_Range_Indicator;
    public Camera Player_cam;

    //if it was the player's turn, now it isn't and vice versa
    public void End_turn()
    {
        isyourturn = !isyourturn;
        if (isyourturn)
        {
            Action_Points = Max_Action_Points;
            Mov_Range_Indicator.GetComponent<MeshRenderer>().enabled = true;
            Player_cam.enabled = true;
        }
        else
        {
            Mov_Range_Indicator.GetComponent<MeshRenderer>().enabled = false;
            Player_cam.enabled = false;
        }
    }
}

