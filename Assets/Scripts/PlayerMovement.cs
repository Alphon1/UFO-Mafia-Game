using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  
    public UnityEngine.AI.NavMeshAgent agent;
    public float maxdistance = 3;
    public GameObject Player_Char;
    private GameObject Game_Manager;
    private Game_Manager gm;


    // Start is called before the first frame update
    void Start()
    {
        
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        gm = Game_Manager.GetComponent<Game_Manager>();
       
    }

    private void Attack(RaycastHit hit)
    {
        Debug.Log("Hit");
        //deal the player's damage to the enemy's current health
        hit.transform.GetComponent<Enemy_Manager>().takedamage(Player_Char.GetComponent<Player_Character>().Damage);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Char.GetComponent<Player_Character>().isyourturn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Player_Char.GetComponent<Player_Character>().Action_Points > 0)
                {
                    Ray ray = Player_Char.GetComponent<Player_Character>().Player_cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    //if you click an enemy
                    if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy")
                    {
                        //checks if there's nothing in the way of the attack
                        if (!Physics.Linecast(Player_Char.transform.position, hit.transform.position, ~(1 << 8)))
                        {
                            //checks if the selected enemy is in range
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
                                agent.SetDestination(hit.point);
                                Debug.Log("Valid point");
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
    