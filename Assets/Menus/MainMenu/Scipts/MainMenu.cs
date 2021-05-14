using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Characterinfomenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();

    }
    public void Show_Char_Info()
    {
        Characterinfomenu.SetActive(true);
    }

    public void Hide_Char_Info()
    {
        Characterinfomenu.SetActive(false);
    }    
}
