using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Character : MonoBehaviour
{
    public int Range;
    public ParticleSystem blood;
    public AudioSource DeathScream;
    [SerializeField]
    private int Max_Health;
    public int Damage;
    private int initiative;
    private int Current_Health;
    public bool isyourturn;
    public int Action_Points;
    [SerializeField]
    private int Max_Action_Points;
    [SerializeField]
    private GameObject Mov_Range_Indicator;
    public Camera Player_cam;
    [SerializeField]
    private Slider healthBar;
    private GameObject Game_Manager;
    private Game_Manager gm;

    private void Start()
    {
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        gm = Game_Manager.GetComponent<Game_Manager>();
        Current_Health = Max_Health;
        playercameraSwitch();




    }
    //if it was the player's turn, now it isn't and vice versa
    public void End_turn()
    {
        isyourturn = !isyourturn;
        if (isyourturn)
        {
            Action_Points = Max_Action_Points;
            Mov_Range_Indicator.GetComponent<MeshRenderer>().enabled = true;
           
            Cursor.lockState = CursorLockMode.Confined;


        }
        else
        {
            Mov_Range_Indicator.GetComponent<MeshRenderer>().enabled = false;
          
            Cursor.lockState = CursorLockMode.None;


        }
    }

    public void Take_Damage(int damagetaken)
    {
        
        Current_Health -= damagetaken;
        healthBar.value = Current_Health;
        DeathScream.Play();
        if (Current_Health <= 0)
        {
            Blood_Animation();
            gm.Turn_Order.Remove(gameObject);
            Destroy(gameObject);
            Debug.Log("Dead");
        }
        Blood_Animation();
    }

    public void Blood_Animation()
    {

        blood.Play();
        ParticleSystem.EmissionModule Emitter = blood.emission;
        Emitter.enabled = true;
    }
    public void playercameraSwitch()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Player_cam.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Player_cam.enabled = false;
        }
    }
}

