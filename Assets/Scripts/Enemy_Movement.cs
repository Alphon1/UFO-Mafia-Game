using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public float maxdistance = 3;
    public GameObject Enemy_Man;
    public GameObject P_Team;
    private GameObject Game_Manager;
    private Game_Manager gm;
    private Vector3 Target;

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
            if (Enemy_Man.GetComponent<Enemy_Manager>().Action_Points > 0)
            {
                Target = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
                if (Vector3.Distance(agent.transform.position, Target) <= maxdistance)
                {
                    //Checks to see if the enemies target position is closer to the players
                    if (Vector3.Distance(agent.transform.position, P_Team.transform.position) > Vector3.Distance(Target, P_Team.transform.position))
                    {
                        agent.SetDestination(Target);
                        Enemy_Man.GetComponent<Enemy_Manager>().Action_Points -= 1;
                        //Update UI here
                        gm.UpdateAPUI(Enemy_Man.GetComponent<Enemy_Manager>().Action_Points);
                    }
                }
            }
        }
    }
}
