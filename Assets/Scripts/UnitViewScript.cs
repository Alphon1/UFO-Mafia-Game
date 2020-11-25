using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitViewScript : MonoBehaviour
{

    public TextMeshProUGUI Playercount;
    public TextMeshProUGUI Enemycount;
    public List<GameObject> Player_list;
    public List<GameObject> Enemy_list;
    // Start is called before the first frame update
    void Start()
    {
        Player_list.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        Enemy_list.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

        UpdatePlayerUnitView(Player_list);
        UpdateEnemyUnitView(Enemy_list);

    }

    // Update is called once per frame
    void Update()
    {

        UpdatePlayerUnitView(Player_list);
        UpdateEnemyUnitView(Enemy_list);
    }
       
    public void UpdatePlayerUnitView(List<GameObject> Player_list)
    {
        int amountOfPlayers = Player_list.Count;
        int i = 0;
        while (i <= Player_list.Count - 1)//for each player character it loop once
        {
          if (Player_list[i] == null)
        {
          amountOfPlayers -= 1;
        }
        i++;
        }
        Playercount.text = amountOfPlayers.ToString();
    }
    public void UpdateEnemyUnitView(List<GameObject> Enemylist)//for each Enemy character it loop once
    {
        int amountOfEnemies = Enemylist.Count;
        int i = 0;
        while (i <= Enemylist.Count - 1)
        {
            if (Enemylist[i] == null)
            {
                amountOfEnemies -= 1;
            }
            i++;
        }
        Enemycount.text = amountOfEnemies.ToString();
    }

}
