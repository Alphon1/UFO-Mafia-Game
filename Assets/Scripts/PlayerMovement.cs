﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{


    public UnityEngine.AI.NavMeshAgent agent;
    public float maxdistance = 3;
    public ParticleSystem Muzzleflash;
    public AudioSource Gunsound;
    public GameObject Player_Char;
    public GameObject ClickIndicator;
    public int damageReduction;
    private int damageReduced;
    private GameObject Game_Manager;
    private Game_Manager gm;
    private GameObject clickindicator;
    private bool Moving;
    private LayerMask coverMask;
    private LayerMask shotMask;


    // Start is called before the first frame update
    void Start()
    {

        Game_Manager = GameObject.FindWithTag("Game_Manager");
        gm = Game_Manager.GetComponent<Game_Manager>();
        coverMask = LayerMask.GetMask("Cover");
        shotMask = LayerMask.GetMask("Default");

    }

    private void Attack(RaycastHit hit)
    {
        Debug.Log("Hit");
        //deal the player's damage to the enemy's current health
        hit.transform.GetComponent<Enemy_Manager>().takedamage(Player_Char.GetComponent<Player_Character>().Damage - damageReduced);

    }


    // Update is called once per frame
    void Update()
    {
        if (Player_Char.GetComponent<Player_Character>().isyourturn)
        {
            if (Moving == true)
            {
                if (!agent.pathPending)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            Moving = false;
                        }
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                        return;
                    if (Player_Char.GetComponent<Player_Character>().Action_Points > 0)
                    {
                        Ray ray = Player_Char.GetComponent<Player_Character>().Player_cam.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        //if you click an enemy
                        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy")
                        {
                            //muzzle flash goes here
                            muzzleFlash();
                            Gunsound.Play();
                            //checks if there's nothing in the way of the attack
                            if (!Physics.Linecast(Player_Char.transform.position, hit.transform.position, shotMask))
                            {
                                damageReduced = 0;
                                if (Physics.Linecast(Player_Char.transform.position, hit.transform.position, coverMask))
                                {
                                    damageReduced = damageReduction;
                                    Debug.Log("Damage Reduced");
                                }
                                //checks if the selected enemy is in range and/or in cover
                                if (Vector3.Distance(Player_Char.transform.position, hit.transform.position) < gameObject.GetComponent<Player_Character>().Range)
                                {
                                    Player_Char.GetComponent<Player_Character>().Action_Points -= 1;
                                    Debug.Log("attacked AP");
                                    //Update UI here
                                    gm.UpdateAPUI(Player_Char.GetComponent<Player_Character>().Action_Points);
                                    Attack(hit);
                                }
                                else
                                {
                                    Debug.Log("Out of Range");
                                }
                            }
                            else
                            {
                                Debug.Log("Something's in the way");
                            }
                        }
                        else if (Physics.Raycast(ray, out hit))
                        {
                            if (Player_Char.GetComponent<Player_Character>().Action_Points > 0)
                            {
                                if (Vector3.Distance(agent.transform.position, hit.point) <= maxdistance)
                                {
                                    Moving = true;
                                    agent.SetDestination(hit.point);
                                    Debug.Log("Valid point");
                                    clickIndicator();
                                    Player_Char.GetComponent<Player_Character>().Action_Points -= 1;
                                    //Update UI here
                                    gm.UpdateAPUI(Player_Char.GetComponent<Player_Character>().Action_Points);
                                }
                                else
                                {
                                    Debug.Log("Invaild point");
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Out of AP");
                    }
                }
            }
        }
    }

    public void clickIndicator()
    {
        clickindicator = Instantiate(ClickIndicator,agent.destination , ClickIndicator.transform.rotation);
        Destroy(clickindicator, 2f);
    }

    public void muzzleFlash()
    {
        Muzzleflash.Play();
        ParticleSystem.EmissionModule Emitter = Muzzleflash.emission;
        Emitter.enabled = true;
    }
}
    