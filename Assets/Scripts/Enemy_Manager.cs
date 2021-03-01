using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


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
    public AudioSource DeathScream;
    [SerializeField]
    private int Max_Action_Points;
    private float Distance_To_Closest_Player = 50;
    private GameObject Closest_Player;
    private GameObject Game_Manager;
    private Game_Manager gm;
    private LinePoints linePoints;
    [SerializeField]
    private GameObject Model;

    //function to reverse if it's this enemy's turn or not
    public void End_turn()
    {
        isyourturn = !isyourturn;
        if (isyourturn)
        {
            Action_Points = Max_Action_Points;
        }
    }

    //sets stats and defines some stuff
    private void Start()
    {
        Current_Health = Max_Health;
        Seen_By = 0;
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        gm = Game_Manager.GetComponent<Game_Manager>();

        //Finds the linePoints scripts
        linePoints = Game_Manager.gameObject.GetComponent<LinePoints>();
    }

    private void Update()
    {
        //turns the enemy visible if the player chars can see it
        if (Seen_By > 0)
        {
            if (Model.activeSelf == false)
            {
                Model.SetActive(true);
                healthBar.gameObject.SetActive(true);
            }
        }
        else
        {
            if (Model.activeSelf == true)
            {
                Model.SetActive(true);
                healthBar.gameObject.SetActive(false);
            }
        }
    }   
    public void takedamage(int damagetaken) {

        Current_Health -= damagetaken;
        healthBar.value = Current_Health;
        DeathScream.Play();
        //detects if it's dead and removes it if it is
        if (Current_Health <= 0)
        {
            linePoints.enemyTarget = gm.Current_Char;
            gm.Turn_Order.Remove(gameObject);
            Seen_By = 0;
            Destroy(gameObject);
            Debug.Log("Dead");
        }
        Blood_Animation();
    }

    public void Blood_Animation()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        ParticleSystem.EmissionModule Emitter = GetComponent<ParticleSystem>().emission;
        Emitter.enabled = true;
    }

}

