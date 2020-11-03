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

    public void LevelOne()
    {
        SceneManager.LoadScene(3);
       
    }
     public void LevelTwo()
    {
        SceneManager.LoadScene(4);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(5);
    }
    public void Credits()
    {
        SceneManager.LoadScene(6);
    }
    


}
