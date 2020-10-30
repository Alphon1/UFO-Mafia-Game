using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitViewScript : MonoBehaviour
{

    public TextMeshProUGUI txt1;
    public TextMeshProUGUI txt2;
    public bool isPaused;
    public GameObject unitMenu;
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                ResumeGame();

            }
            else
            {
                UpdatePlayerUnitView(Player_list);
                UpdateEnemyUnitView(Enemy_list);

                isPaused = true;
                unitMenu.SetActive(true);
                
            }
      
        }

    }
        public void ResumeGame()
        {
            isPaused = false;
            unitMenu.SetActive(false);
            
            
        }
    public void UpdatePlayerUnitView(List<GameObject> Playerlist)
    {
        int amountOfPlayers = Playerlist.Count;
        int i = 0;
        while (i <= Playerlist.Count - 1)//for each player character it loop once
        {
            if (Playerlist[i] == null)
            {
                amountOfPlayers -= 1;
            }
            i++;
        }
        txt1.text = Playerlist.ToString();
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
        txt2.text = amountOfEnemies.ToString();
    }

}
