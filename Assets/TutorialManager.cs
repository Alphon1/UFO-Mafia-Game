using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject apExplainer;
    public GameObject turnOrderExplainer;
    public float waitTime = 2f;
   

    public void Update()
    {
        for (int i = 0; i <popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.D)))))
            {
                popUpIndex++;
            }
            else if (popUpIndex == 1)
            {
                if (Input.mouseScrollDelta.y != 0)
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 3)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 4)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 5)
            {
                if (Input.GetMouseButtonDown(2))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 6)
            {
                if (Input.GetKeyDown(KeyCode.C) || (Input.GetKeyDown(KeyCode.X)))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 7)
            {
                apExplainer.SetActive(true);
                waitTime -= Time.deltaTime;
                popUpIndex++;
            }
            else if (popUpIndex == 8)
            {
                apExplainer.SetActive(false);
                turnOrderExplainer.SetActive(true);
                waitTime -= Time.deltaTime;
                popUpIndex++;
            }
            else if (popUpIndex == 9)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
