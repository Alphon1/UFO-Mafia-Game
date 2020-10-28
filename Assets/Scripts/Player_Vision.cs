using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Vision : MonoBehaviour
{
    [SerializeField]
    private GameObject Player_Character;
    public List<GameObject> Seen_Enemies;

    //Every frame an enemy is within sight range of the player
    private void OnTriggerStay(Collider Enemy)
    {
        //if there's nothing in between them
        if (!Physics.Linecast(Player_Character.transform.position, Enemy.transform.position, ~(1 << 8)))
        {
            //if the player didn't already see this enemy
            if(!Seen_Enemies.Contains(Enemy.gameObject))
            {
                //tells the enemy a player can see it
                Enemy.GetComponent<Enemy_Manager>().Seen_By += 1;
                //makes a note that the player has seen this enemy, so can't see them again.
                Seen_Enemies.Add(Enemy.gameObject);
            }
        }
        //if the player can't see the enemy
        else
        {
            //if the player was seeing the enemy previously
            if (Seen_Enemies.Contains(Enemy.gameObject))
            {
                //tell the enemy a player can't see it anymore
                Enemy.GetComponent<Enemy_Manager>().Seen_By -= 1;
                //notes that the player can't see this enemy
                Seen_Enemies.Remove(Enemy.gameObject);
            }
        }
    }

    //if the enemy moves out of range of the player's sight
    private void OnTriggerExit(Collider Exiting_Enemy)
    {
        //the same checking/notifying code from if there's an object in the way
        if (Seen_Enemies.Contains(Exiting_Enemy.gameObject))
        {
            Exiting_Enemy.GetComponent<Enemy_Manager>().Seen_By -= 1;
            Seen_Enemies.Remove(Exiting_Enemy.gameObject);
        }
    }
}
