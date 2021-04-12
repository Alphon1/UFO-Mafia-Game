using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;
    public Camera MainCamera;
    public float maxdistance = 3;
    public ParticleSystem Muzzleflash;
    public AudioSource Gunsound;
    public GameObject Player_Char;
    public GameObject ClickIndicator;
    public int damageReduction;
    public bool Moving;
    public GameObject gun;
    public GameObject bulletPrefab;
    private Transform coverDetect;
    private int damageReduced;
    private GameObject Game_Manager;
    private Game_Manager gm;
    private GameObject clickindicator;
    private LayerMask coverMask;
    private LayerMask shotMask;
    private Transform gfx;
    private Animator animator;
    public AudioSource Movingup;
    private bool blocked = false;
    private NavMeshHit navHit;
    public bool can_act = true;


    // Start is called before the first frame update
    void Start()
    {
        coverDetect = gameObject.transform.Find("CoverDetect");
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        gm = Game_Manager.GetComponent<Game_Manager>();
        coverMask = LayerMask.GetMask("Cover");
        shotMask = LayerMask.GetMask("Default");
        gfx = this.gameObject.transform.GetChild(0);
        animator = gfx.gameObject.GetComponent<Animator>();

    }

    private void Attack(RaycastHit hit)
    {
        End_if_0ap();
        //deal the player's damage to the enemy's current health
        hit.transform.GetComponent<Enemy_Manager>().takedamage(Player_Char.GetComponent<Player_Character>().Damage - damageReduced);
    }

    private void End_if_0ap()
    {
        if (Player_Char.GetComponent<Player_Character>().Action_Points < 1)
        {
            gm.Turn_End();
        }
    }

    public void Set_Wounded_Idle()
    {
        Moving = false;
        animator.SetBool("isWounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving == true)
        {
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (agent.velocity.sqrMagnitude == 0f)
                    {
                        Moving = false;
                        animator.SetBool("isWalking", false);
                    }
                }
            }
        }

        if (Player_Char.GetComponent<Player_Character>().isyourturn)
        {
            if (can_act)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                        return;
                    if (Player_Char.GetComponent<Player_Character>().Action_Points > 0)
                    {
                        //Ray ray = Player_Char.GetComponent<Player_Character>().Player_cam.ScreenPointToRay(Input.mousePosition);
                        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

                        RaycastHit hit;
                        //audio goes here
                        //if you click an enemy
                        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy")
                        {
                            if (Player_Char.GetComponent<Player_Character>().Is_Attacking)
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
                                    //checks if the selected enemy is in range
                                    if (Vector3.Distance(Player_Char.transform.position, hit.transform.position) < gameObject.GetComponent<Player_Character>().Shoot_Range)
                                    {
                                        animator.SetTrigger("Shoot");
                                        Player_Char.GetComponent<Player_Character>().Action_Points -= 1;
                                        Debug.Log("attacked AP");
                                        //Update UI here
                                        gm.UpdateAPUI(Player_Char.GetComponent<Player_Character>().Action_Points);
                                        Attack(hit);
                                        GameObject bulletObject = Instantiate(bulletPrefab);
                                        bulletObject.transform.position = gun.transform.position + gun.transform.forward;
                                        bulletObject.transform.forward = gun.transform.forward;
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
                                coverDetect.gameObject.transform.localPosition = new Vector3(0, 100, 0);
                            }
                        }
                        else if (Physics.Raycast(ray, out hit))
                        {
                            if (Player_Char.GetComponent<Player_Character>().Action_Points > 0)
                            {
                                if (Player_Char.GetComponent<Player_Character>().Is_Attacking == false)
                                {
                                    if (Vector3.Distance(Player_Char.transform.position, hit.point) < gameObject.GetComponent<Player_Character>().Move_Range)
                                    {
                                        animator.SetBool("isWalking", true);
                                        Moving = true;
                                        Movingup.Play();
                                        agent.SetDestination(hit.point);
                                        Debug.Log("Valid point");
                                        clickIndicator();
                                        Player_Char.GetComponent<Player_Character>().Action_Points -= 1;
                                        //Update UI here
                                        gm.UpdateAPUI(Player_Char.GetComponent<Player_Character>().Action_Points);
                                        End_if_0ap();
                                    }
                                    else
                                    {
                                        Debug.Log("Invaild point");
                                    }
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
    