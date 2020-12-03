using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonscript : MonoBehaviour
{
    
    // Start is called before the first frame update
   
    public void LoadnextScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelOnetutscreen()
    {
        SceneManager.LoadScene(3);
       
    }
     public void LevelTwo()
    {
        SceneManager.LoadScene(7);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(8);
    }
    public void Credits()
    {
        SceneManager.LoadScene(9);
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Tolevelone()
    {
        SceneManager.LoadScene(6);
    }




}
