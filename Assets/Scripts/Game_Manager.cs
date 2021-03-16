using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public List<GameObject> Turn_Order = new List<GameObject>();
    public GameObject playerTurnIndicator;
    public GameObject enemyTurnIndicator;
    private NavMeshObstacle navMO;
    private int Random_Int;
    private GameObject Temp_Char;    
    public int Current_Char_Pos;
    public GameObject Current_Char;
    public bool Is_Player_Turn;
    private LinePoints linePoints;
    [SerializeField]
    private GameObject Turn_Order_Manager;
    [SerializeField]
    private GameObject End_Text;
    [SerializeField]
    private GameObject End_Screen;
    [SerializeField]
    private Text Mode_Change_Button_Text;

    // Start is called before the first frame update
    void Awake()
    {
        linePoints = this.gameObject.GetComponent<LinePoints>();

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
        linePoints.enemyTarget = Current_Char;
        if(Current_Char.tag == "Player")
        {
            playerTurnIndicator.SetActive(true);
            Is_Player_Turn = true;
            Current_Char.GetComponent<Player_Character>().End_turn();
        }
        else
        {
            enemyTurnIndicator.SetActive(true);
            Is_Player_Turn = false;
            Current_Char.GetComponent<Enemy_Manager>().End_turn();
        }
        if (Current_Char.GetComponent<Player_Character>())
        {
            UpdateAPUI(Current_Char.GetComponent<Player_Character>().Action_Points);
        }
    }

    public void End_Game(bool Victory)
    {
        End_Screen.SetActive(true);
        if (Victory)
        {
            End_Text.GetComponent<TextMeshProUGUI>().text = "VICTORY";
        }
        else
        {
            End_Text.GetComponent<TextMeshProUGUI>().text = "DEFEAT";
        }
    }
    //is called when the end turn button is pressed, disables control of the current character and enables it for the next
    public void Turn_End()
    {
        if (Current_Char.tag == "Player")
        {
            Current_Char.GetComponent<Player_Character>().End_turn();   
        }
        else
        {
            Current_Char.GetComponent<Enemy_Manager>().End_turn();   
        }
        Current_Char_Pos += 1;
        if (Current_Char_Pos > Turn_Order.Count - 1)
        {
            Current_Char_Pos = 0;
        }
        Current_Char = Turn_Order[Current_Char_Pos];
        linePoints.enemyTarget = Current_Char;
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
        Turn_Order_Manager.GetComponent<Turn_Order_UI>().Update_UI();
        UpdateAPUI(Current_Char.GetComponent<Player_Character>().Action_Points);
        Mode_Change_Button_Text.text = "Attack";
    }
    public void UpdateAPUI(int APvalue)
    {
        txt.text = APvalue.ToString();
        
    }
    public void Change_Player_Mode()
    {
        if (Current_Char.tag == "Player")
        {
            Current_Char.GetComponent<Player_Character>().Switch_Action();
            if (Mode_Change_Button_Text.text == "Attack")
            {
                Mode_Change_Button_Text.text = "Move";
            }
            else
            {
                Mode_Change_Button_Text.text = "Attack";
            }
        }
    }
}
