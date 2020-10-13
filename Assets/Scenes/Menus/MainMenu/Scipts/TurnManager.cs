using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private List<GameObject> char_list;
    private int Random_Int;
    private GameObject Temp_Char;
    private GameObject Current_Char;
    private int Current_Char_Pos;
    // Start is called before the first frame update
    void Start()
    {

                
            char_list.AddRange(GameObject.FindGameObjectsWithTag("Player"));
            
        
        System.Random New_Random = new System.Random();
        for (int i = 0; i < char_list.Count; i++)
        {
            Random_Int = i + (int)(New_Random.NextDouble() * (char_list.Count - i));
            Temp_Char = char_list[Random_Int];
            char_list[Random_Int] = char_list[i];
            char_list[i] = Temp_Char;



        }
        Current_Char_Pos = 0;
        Current_Char = char_list[Current_Char_Pos];

        Current_Char.GetComponent<Player_Character>().End_turn();
    }
    public void Turn_End()
    {
        Current_Char.GetComponent<Player_Character>().End_turn();
        Current_Char_Pos += 1;
        if (Current_Char_Pos > char_list.Count -1)
        {
            Current_Char_Pos = 0;
        }
        Current_Char = char_list[Current_Char_Pos];
        Current_Char.GetComponent<Player_Character>().End_turn();
    }
}
