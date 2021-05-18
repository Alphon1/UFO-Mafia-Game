using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Game_Managerfortut : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public List<GameObject> Turn_Order = new List<GameObject>();
    public GameObject APMenu;
    public GameObject playerTurnIndicator;
    public GameObject enemyTurnIndicator;
    private NavMeshObstacle navMO;
    private int Random_Int;
    private GameObject Temp_Char;    
    public int Current_Char_Pos;
    public GameObject Current_Char;
    public bool Is_Player_Turn;
    public GameObject[] popUps;
    private int popUpIndex;
    public float waitTime = 2f;
    public GameObject Player_Char;
    private Linepointsfortut linePoints;
    [SerializeField]
    private Text Mode_Change_Button_Text;
    [SerializeField]
    private Button Mode_Change_Button;
    [SerializeField]
    private Sprite Attack_Image;
    [SerializeField]
    private Sprite Move_Image;


    [SerializeField]
    //private GameObject Turn_Order_Manager;

    // Start is called before the first frame update
    void Start()
    {
        linePoints = this.gameObject.GetComponent<Linepointsfortut>();
        //makes a list of all player characters
        Turn_Order.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //Turn_Order.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        

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
        if (Current_Char.tag == "Player")
        {
            
            playerTurnIndicator.SetActive(true);
            Is_Player_Turn = true;
            Current_Char.GetComponent<Player_Characterfortut>().End_turn();
        }        
        if (Current_Char.GetComponent<Player_Characterfortut>())
        {
            UpdateAPUI(Current_Char.GetComponent<Player_Characterfortut>().Action_Points);
            
        }
        //Turn_Order_Manager.GetComponent<Turn_Order_UI_fortut>().Update_UI();



    }

   void Update()
    {
        UpdateAPUI(Player_Char.GetComponent<Player_Characterfortut>().Action_Points);
 

        if (Is_Player_Turn == true)
        {
            
            for (int i = 0; i < popUps.Length; i++)
            {
                if (i == popUpIndex)
                {
                    popUps[popUpIndex].SetActive(true);
                    
                }
                else
                {
                    popUps[popUpIndex].SetActive(false);
                }
            }
            if (popUpIndex == 0)
            {
                popUps[popUpIndex].SetActive(true);
                if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.D)))))
                {
                    Debug.Log("is triggering");
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 1)
            {
                popUps[popUpIndex].SetActive(true);
                if (Input.mouseScrollDelta.y != 0)
                {
                    popUps[popUpIndex].SetActive(false);
                    Debug.Log("is scroll wheel pop");
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 2)
            {

                popUps[popUpIndex].SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }

            }
            else if (popUpIndex == 3)
            {

                popUps[popUpIndex].SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }

            }
            else if (popUpIndex == 4)
            {
                popUps[popUpIndex].SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 5)
            {
                popUps[popUpIndex].SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 6)
            {
                popUps[popUpIndex].SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 7)
            {
                popUps[popUpIndex].SetActive(true);
                if (Input.GetMouseButtonDown(2))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 8)
            {
                popUps[popUpIndex].SetActive(true);
                if (Input.GetKeyDown(KeyCode.C) || (Input.GetKeyDown(KeyCode.X)))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 9)
            {
                popUps[popUpIndex].SetActive(true);
                if (Input.GetKeyDown(KeyCode.X))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 10)
            {
                popUps[popUpIndex].SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                }
                
            }
            else if (popUpIndex == 11)
            {
                popUps[popUpIndex].SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;

                }
            }
            
            else if (popUpIndex == 12)
            {



            }
            if (popUpIndex == 12)
            {
                waitTime -= Time.deltaTime;
                SceneManager.LoadScene(3);
            }  
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
            Current_Char.GetComponent<Player_Characterfortut>().End_turn();   
        }
        else
        {
            Current_Char.GetComponent<Enemy_Managerfortut>().End_turn();   
        }
        Current_Char_Pos += 1;
        if (Current_Char_Pos > Turn_Order.Count - 1)
        {
            Current_Char_Pos = 0;
        }
        Current_Char = Turn_Order[Current_Char_Pos];
        linePoints.enemyTarget = Current_Char;
        //Turn_Order_Manager.GetComponent<Turn_Order_UI_fortut>().Update_UI();

        if (Current_Char.tag == "Player")
        {
            playerTurnIndicator.SetActive(true);
            enemyTurnIndicator.SetActive(false);
            //Current_Char.GetComponent<Player_Character>().End_turn();
            Is_Player_Turn = true;
            
        }
        Mode_Change_Button_Text.text = "Attack";

        UpdateAPUI(Current_Char.GetComponent<Player_Characterfortut>().Action_Points);
        //Turn_Order_Manager.GetComponent<Turn_Order_UI_fortut>().Update_UI();
    }
    public void UpdateAPUI(int APvalue)
    {
        txt.text = APvalue.ToString();
        
    }
    public void Change_Player_Mode()
    {
        if (Current_Char.tag == "Player")
        {
            Current_Char.GetComponent<Player_Characterfortut>().Switch_Action();
            if (Mode_Change_Button_Text.text == "Attack")
            {
                Mode_Change_Button_Text.text = "Move";
                Mode_Change_Button.image.sprite = Move_Image;
            }
            else
            {
                Mode_Change_Button_Text.text = "Attack";
                Mode_Change_Button.image.sprite = Attack_Image;
            }
        }
    }



}

