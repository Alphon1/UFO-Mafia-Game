using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class Player_Character : MonoBehaviour
{
    public int Range;
    public ParticleSystem blood;
    public AudioSource DeathScream;
    public GameObject PlayerIndicator;
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
    public GameObject playerCam;
    private GameObject Main_camera;
    [SerializeField]
    private Slider healthBar;
    private GameObject Game_Manager;
    private Game_Manager gm;



    private void Start()
    {
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        gm = Game_Manager.GetComponent<Game_Manager>();
        Current_Health = Max_Health;





    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isyourturn)
            {
                playerCamOn();
            }
            else
            {
                playerCamOff();

            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                playerCamOff();
            }
        }

    }

    //if it was the player's turn, now it isn't and vice versa
    [System.Obsolete]
    public void End_turn()
    {
        isyourturn = !isyourturn;
        if (isyourturn)
        {
            Action_Points = Max_Action_Points;
            Mov_Range_Indicator.GetComponent<MeshRenderer>().enabled = true;
            PlayerIndicator.GetComponent<MeshRenderer>().enabled = true;
            Cursor.lockState = CursorLockMode.Confined;











        }
        else
        {
            Mov_Range_Indicator.GetComponent<MeshRenderer>().enabled = false;
            PlayerIndicator.GetComponent<MeshRenderer>().enabled = false;
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
    void playerCamOn()
    {
        playerCam.GetComponentInChildren<CinemachineFreeLook>().enabled = true;
        Main_camera.SetActive(false);
        //playerCam.SetActive(true);
    }
    void playerCamOff()
    {
        playerCam.GetComponentInChildren<CinemachineFreeLook>(enabled).enabled = false;
        Main_camera.SetActive(true);
        //playerCam.SetActive(false);
    }

   
}
   

