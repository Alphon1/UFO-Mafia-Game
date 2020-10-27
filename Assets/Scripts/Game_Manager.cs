using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public List<GameObject> Player_list;
    public List<GameObject> Visible_Enemies;
    public List<GameObject> Enemy_List;
    private int Random_Int;
    private GameObject Temp_Char;
    private GameObject Current_Char;
    private int Current_Char_Pos;
    // Start is called before the first frame update
    void Start()
    {
        Enemy_List.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        Player_list.AddRange(GameObject.FindGameObjectsWithTag("Tonies")); 

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
    }
    private void Update()
    {
        Check_Visible_Enemies();
    }
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
    }
    public void Check_Visible_Enemies()
    {
        Visible_Enemies.Clear();
        foreach (GameObject Character in Player_list)
        {
            Character.GetComponentInChildren<Player_Vision>().Check_Local_Visible_Enemies();
        }
        foreach (GameObject Enemy in Enemy_List)
        {
            if (!Visible_Enemies.Contains(Enemy))
            {
                Enemy.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                Enemy.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
