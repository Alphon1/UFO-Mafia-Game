using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy_Manager : MonoBehaviour
{
    public int Range;
    [SerializeField]
    private int Max_Health;
    public int Damage;
    private int initiative;
    public int Current_Health;
    public bool isyourturn;
    public int Seen_By;
    public Slider healthBar;
    public int Action_Points;
    [SerializeField]
    private int Max_Action_Points;
    private float Distance_To_Closest_Player = 50;
    private GameObject Closest_Player;
    private GameObject Game_Manager;
    private Game_Manager gm;

    //function to reverse if it's this enemy's turn or not
    public void End_turn()
    {
        isyourturn = !isyourturn;
        if (isyourturn)
        {
            Action_Points = Max_Action_Points;
            foreach (GameObject Player in GameObject.FindGameObjectsWithTag("Player"))
            {
                if(Vector3.Distance(Player.transform.position, gameObject.transform.position) < Distance_To_Closest_Player)
                Distance_To_Closest_Player = Vector3.Distance(Player.transform.position, gameObject.transform.position);
                Closest_Player = Player;
            }
            gameObject.GetComponent<Enemy_Movement>().P_Team = Closest_Player;
        }
    }

    public void Blood_Animation()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        ParticleSystem.EmissionModule Emitter = GetComponent<ParticleSystem>().emission;
        Emitter.enabled = true;
    }

    //sets stats and defines some stuff
    private void Start()
    {
        Current_Health = Max_Health;
        Seen_By = 0;
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        gm = Game_Manager.GetComponent<Game_Manager>();
    }

    private void Update()
    {
        //turns the enemy visible if the player chars can see it
        if (Seen_By > 0)
        {
            if (gameObject.GetComponent<Renderer>().enabled == false)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                healthBar.gameObject.SetActive(true);
            }
        }
        else
        {
            if (gameObject.GetComponent<Renderer>().enabled == true)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                healthBar.gameObject.SetActive(false);
            }
        }
    }   
    public void takedamage(int damagetaken) {
        Current_Health -= damagetaken;
        healthBar.value = Current_Health;
        Blood_Animation();
        //detects if it's dead and removes it if it is
        if (Current_Health <= 0)
        {
            gm.Turn_Order.Remove(gameObject);
            Seen_By = 0;
            Destroy(gameObject);
            Debug.Log("Dead");
        }
    }

    
}

