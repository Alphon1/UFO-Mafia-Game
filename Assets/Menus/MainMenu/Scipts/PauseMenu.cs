using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public string mainMenuScene;
    public GameObject pauseMenu;
    public GameObject Buttons;
    public GameObject APMenu;
    public bool isPaused;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();

            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Buttons.SetActive(false);
                APMenu.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Buttons.SetActive(true);
        APMenu.SetActive(true);
        Time.timeScale = 1f;
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ReturnToLevelselect()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 1f;

    }
}