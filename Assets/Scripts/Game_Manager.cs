using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public List<GameObject> Player_list;
    private int Random_Int;
    private GameObject Temp_Char;
    private GameObject Current_Char;
    private int Current_Char_Pos;
        // Start is called before the first frame update
    void Start()
    {
        //makes a list of all player characters
        Player_list.AddRange(GameObject.FindGameObjectsWithTag("Player")); 

        //randomizes the list of player characters
        System.Random New_Random = new System.Random();
        for (int i = 0; i < Player_list.Count; i++)
        {
            Random_Int = i + (int)(New_Random.NextDouble() * (Player_list.Count - i));
            Temp_Char = Player_list[Random_Int];
            Player_list[Random_Int] = Player_list[i];
            Player_list[i] = Temp_Char;
        }
        Current_Char_Pos = 0;
        Current_Char = Player_list[Current_Char_Pos];
        Current_Char.GetComponent<Player_Character>().End_turn();
        UpdateAPUI(Current_Char.GetComponent<Player_Character>().Action_Points);
    }

    //is called when the end turn button is pressed, disables control of the current character and enables it for the next
    public void Turn_End()
    {
        Current_Char.GetComponent<Player_Character>().End_turn();
        Current_Char_Pos += 1;
        if (Current_Char_Pos > Player_list.Count -1)
        {
            Current_Char_Pos = 0;
        }
        Current_Char = Player_list[Current_Char_Pos];
        Current_Char.GetComponent<Player_Character>().End_turn();
        UpdateAPUI(Current_Char.GetComponent<Player_Character>().Action_Points);
        }
    public void UpdateAPUI(int APvalue)
    {
        txt.text = APvalue.ToString();
        Debug.Log("APUI "+APvalue);
    }
   
}
