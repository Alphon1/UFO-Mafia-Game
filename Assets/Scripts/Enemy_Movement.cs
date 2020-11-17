using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public float maxdistance;
    public GameObject Enemy_Man;
    public GameObject P_Team;
    private GameObject Game_Manager;
    private Game_Manager gm;
    private Vector3 Target;
    private bool Moving;

    void Start()
    {
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        gm = Game_Manager.GetComponent<Game_Manager>();
    }

    void Update()
    {
        //Enemies currently aren't in the turn order as such they have one immediate turn.
        if (Enemy_Man.GetComponent<Enemy_Manager>().isyourturn)
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
            if (Enemy_Man.GetComponent<Enemy_Manager>().Action_Points > 0)
            {
                if (!Moving)
                {
                    if (Vector3.Distance(P_Team.transform.position,gameObject.transform.position)< gameObject.GetComponent<Enemy_Manager>().Range && !Physics.Linecast(gameObject.transform.position, P_Team.transform.position, ~(1 << 8)))
                    {
                        Enemy_Man.GetComponent<Enemy_Manager>().Action_Points -= 1;
                        //Update UI here
                        gm.UpdateAPUI(Enemy_Man.GetComponent<Enemy_Manager>().Action_Points);
                        P_Team.GetComponent<Player_Character>().Take_Damage(gameObject.GetComponent<Enemy_Manager>().Damage);
                    }
                    Target = new Vector3(Random.Range(Enemy_Man.transform.position.x - maxdistance / 2, Enemy_Man.transform.position.x + maxdistance / 2), 0, Random.Range(Enemy_Man.transform.position.z - maxdistance / 2, Enemy_Man.transform.position.z + maxdistance / 2));
                    //Checks to see if the enemies target position is closer to the players
                    if (Vector3.Distance(agent.transform.position, P_Team.transform.position) > Vector3.Distance(Target, P_Team.transform.position))
                    {
                        Moving = true;
                        agent.SetDestination(Target);
                        Enemy_Man.GetComponent<Enemy_Manager>().Action_Points -= 1;
                        //Update UI here
                        gm.UpdateAPUI(Enemy_Man.GetComponent<Enemy_Manager>().Action_Points);
                    }
                }
            }
            else
            {
                Game_Manager.GetComponent<Game_Manager>().Turn_End();
            }
        }
    }
}
