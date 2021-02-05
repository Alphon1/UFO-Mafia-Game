using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public List<GameObject> Turn_Order;
    public GameObject playerTurnIndicator;
    public GameObject enemyTurnIndicator;
    private NavMeshObstacle navMO;
    private int Random_Int;
    private GameObject Temp_Char;    
    private int Current_Char_Pos;
    public GameObject Current_Char;
    public bool Is_Player_Turn;

    // Start is called before the first frame update
    void Start()
    {
        //makes a list of all player characters
        Turn_Order.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        Turn_Order.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

        //randomizes the list of player characters
        System.Random New_Random = new System.Random();
        for (int i = 0; i < Turn_Order.Count; i++)
        {
            Random_Int = i + (int)(New_Random.NextDouble() * (Turn_Order.Count - i));
            Temp_Char = Turn_Order[Random_Int];
            Turn_Order[Random_Int] = Turn_Order[i];
            Turn_Order[i] = Temp_Char;
        }
        Current_Char_Pos = 0;
        Current_Char = Turn_Order[Current_Char_Pos];
        if(Current_Char.tag == "Player")
        {
            Is_Player_Turn = true;
            Current_Char.GetComponent<Player_Character>().End_turn();
        }
        else
        {
            Is_Player_Turn = false;
            Current_Char.GetComponent<Enemy_Manager>().End_turn();
        }
        if (Current_Char.GetComponent<Player_Character>())
        {
            UpdateAPUI(Current_Char.GetComponent<Player_Character>().Action_Points);
        }


    }

    //is called when the end turn button is pressed, disables control of the current character and enables it for the next
    public void Turn_End()
    {
        //if all enemies are dead
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 || GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            //go to level select
            SceneManager.LoadScene(2);
            Time.timeScale = 1f;
        }
        if (Current_Char.tag == "Player")
        {
            Current_Char.GetComponent<Player_Character>().End_turn();   
        }
        else
        {
            Current_Char.GetComponent<Enemy_Manager>().End_turn();   
        }
        Current_Char_Pos += 1;
        if (Current_Char_Pos > Turn_Order.Count -1)
        {
            Current_Char_Pos = 0;
        }
        Current_Char = Turn_Order[Current_Char_Pos];
        if (Current_Char.tag == "Player")
        {
            playerTurnIndicator.SetActive(true);
            enemyTurnIndicator.SetActive(false);
            Current_Char.GetComponent<Player_Character>().End_turn();
            Is_Player_Turn = true;
        }
        else
        {
            playerTurnIndicator.SetActive(false);
            enemyTurnIndicator.SetActive(true);
            Current_Char.GetComponent<Enemy_Manager>().End_turn();
            Is_Player_Turn = false;
        }
        UpdateAPUI(Current_Char.GetComponent<Player_Character>().Action_Points);
        
    }
    public void UpdateAPUI(int APvalue)
    {
        txt.text = APvalue.ToString();
        
    }
}
