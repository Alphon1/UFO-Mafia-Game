using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyColourChange : MonoBehaviour
{
    public Material baseMaterial;
    public Material highlightedColour;
    private Game_Manager Game_Manager_Script;
    private GameObject Game_Manager;
    private bool Health_Visible = true;
    private Slider Health_Bar;
    private bool Health_Flashing;

    public void Start()
    {
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        Game_Manager_Script = Game_Manager.GetComponent<Game_Manager>();
        Health_Bar = gameObject.GetComponentInChildren<Slider>();
    }

    public void OnMouseOver()
    {
        //Checks if it's the player's turn, and the enemy is within range
        if (Game_Manager_Script.Is_Player_Turn && Vector3.Distance(Game_Manager.GetComponent<Game_Manager>().Current_Char.transform.position, gameObject.transform.position) < Game_Manager.GetComponent<Game_Manager>().Current_Char.GetComponent<Player_Character>().Range)
        {
            
            GetComponent<Renderer>().material = highlightedColour;
            if (Health_Flashing == false)
            {
                StartCoroutine(Flash_Healthbar());
            }
        }
    }
    public void OnMouseExit()
    {
        GetComponent<Renderer>().material = baseMaterial;
        Health_Bar.value = gameObject.GetComponent<Enemy_Manager>().Current_Health;
        StopCoroutine(Flash_Healthbar());
        Health_Flashing = false;
    }

    IEnumerator Flash_Healthbar()
    {
        Health_Flashing = true;
        if (Health_Visible)
        {
            //simulates the healthbar to if the current character hits this enemy
            Health_Bar.value = Health_Bar.value - (Game_Manager.GetComponent<Game_Manager>().Current_Char.GetComponent<Player_Character>().Damage - Game_Manager.GetComponent<Game_Manager>().Current_Char.GetComponent<PlayerMovement>().damageReduction);
            Health_Visible = false;
        }
        else
        {
            Health_Bar.value = gameObject.GetComponent<Enemy_Manager>().Current_Health;
            Health_Visible = true;
        }
        yield return new WaitForSeconds(0.5f);
        Health_Flashing = false;
    }
}

