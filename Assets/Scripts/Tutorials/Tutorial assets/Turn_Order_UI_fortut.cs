using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Turn_Order_UI_fortut : MonoBehaviour
{
    public GameObject Game_Manager;
    public Game_Managerfortut Game_Manager_Script;
    [SerializeField]
    private GameObject Slot1;
    [SerializeField]
    private GameObject Slot2;
    private List<GameObject> Turn_Order_Slots = new List<GameObject>();
    private int Current_Displayed_Char_Pos;
    // Start is called before the first frame update
    public void awake()
    {
        Turn_Order_Slots.Add(Slot1);
        Turn_Order_Slots.Add(Slot2);
           
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        Game_Manager_Script = Game_Manager.GetComponent<Game_Managerfortut>();
      

    }
    public void Update_UI()
    {
        for (int i = 0; i < 2; i++)
        {        
            if (Game_Manager_Script.Current_Char_Pos + i > Game_Manager_Script.Turn_Order.Count)
            {
                Current_Displayed_Char_Pos = Game_Manager_Script.Current_Char_Pos + i - Game_Manager_Script.Turn_Order.Count;
            }
            else
            {
                Current_Displayed_Char_Pos = Game_Manager_Script.Current_Char_Pos + i;
            }
            Debug.Log(Turn_Order_Slots[i].name);
            Turn_Order_Slots[i].GetComponentInChildren<TextMeshProUGUI>().text = Game_Manager_Script.Turn_Order[Current_Displayed_Char_Pos].name;
            if (Game_Manager_Script.Turn_Order[Current_Displayed_Char_Pos].tag == "Enemy")
            {
                Turn_Order_Slots[i].GetComponent<Image>().color = new Color32(220, 20, 60, 255);
            }
            else if (Game_Manager_Script.Turn_Order[Current_Displayed_Char_Pos].tag == "Player")
            {
                Turn_Order_Slots[i].GetComponent<Image>().color = new Color32(70, 130,180, 255);
            }
        }
    }
}
