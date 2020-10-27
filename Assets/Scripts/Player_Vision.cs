using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Vision : MonoBehaviour
{
    [SerializeField]
    private GameObject Player_Character;
    private GameObject Game_Manager;
    public List<GameObject> Nearby_Enemies;
    private void Start()
    {
        Game_Manager = GameObject.FindWithTag("Game_Manager");

    }
    private void OnTriggerEnter(Collider Entering_Enemy)
    {
        Nearby_Enemies.Add(Entering_Enemy.gameObject);
    }
    private void OnTriggerExit(Collider Exiting_Enemy)
    {
        Nearby_Enemies.Remove(Exiting_Enemy.gameObject);
    }
    public void Check_Local_Visible_Enemies()
    {
        foreach (GameObject Enemy in Nearby_Enemies)
        {
            if (!Physics.Linecast(Player_Character.transform.position, Enemy.transform.position, ~(1 << 8)))
            {
                if(!Game_Manager.GetComponent<Game_Manager>().Visible_Enemies.Contains(Enemy))
                {
                    Game_Manager.GetComponent<Game_Manager>().Visible_Enemies.Add(Enemy);
                }
            }
        }
    }
}
