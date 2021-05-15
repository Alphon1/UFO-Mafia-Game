using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
//using UnityEngine.Rendering.Universal;

public class OptionsScript : MonoBehaviour
{

    public GameObject scoutscreen;
    public GameObject allrounderscreen;
    public GameObject Tankscreen;
    public GameObject Sniperscreen;
    public GameObject Charselectscreen;
    public GameObject pausemenubuttons;
    public void Scoutscreen()
    {
        scoutscreen.SetActive(true);
        Charselectscreen.SetActive(false);
    }
    public void AllRounderscreen()
    {
        allrounderscreen.SetActive(true);
        Charselectscreen.SetActive(false);
    }
    public void tankscreen()
    {
        Tankscreen.SetActive(true);
        Charselectscreen.SetActive(false);
    }
    public void sniperScreen()
    {
        Sniperscreen.SetActive(true);
        Charselectscreen.SetActive(false);
    }
    public void BacktoCharinfomenu()
    {
        scoutscreen.SetActive(false);
        allrounderscreen.SetActive(false);
        Tankscreen.SetActive(false);
        Sniperscreen.SetActive(false);
        Charselectscreen.SetActive(true);
    }
    public void Backtopausemenu()
    {
        
        Charselectscreen.SetActive(false);
        pausemenubuttons.SetActive(true);

    }
}
