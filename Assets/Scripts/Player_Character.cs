using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;
public class Player_Character : MonoBehaviour
{
    public int Move_Range;
    public int Shoot_Range;
    public VisualEffect blood;
    public AudioSource PainScream;
    public AudioSource DeathScream;
    public GameObject PlayerIndicator;
    public GameObject ragDoll;
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
    private GameObject Action_Range_Indicator;
    public GameObject playerCam;
    private GameObject Main_camera;
    [SerializeField]
    private Slider healthBar;
    private GameObject Game_Manager;
    private Game_Manager gm;
    public bool Is_Attacking;
    [SerializeField]
    private Material Move_Circle;
    [SerializeField]
    private Material Attack_Circle;



    private void Start()
    {
        Game_Manager = GameObject.FindWithTag("Game_Manager");
        gm = Game_Manager.GetComponent<Game_Manager>();
        Action_Range_Indicator.transform.localScale = new Vector3(Move_Range *2, 0, Move_Range*2);
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
    public void End_turn()
    {
        isyourturn = !isyourturn;
        if (isyourturn)
        {
            Action_Points = Max_Action_Points;
            Action_Range_Indicator.GetComponent<MeshRenderer>().enabled = true;
            PlayerIndicator.GetComponent<MeshRenderer>().enabled = true;
            if (Is_Attacking)
            {
                Switch_Action();
            }
            //Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Action_Range_Indicator.GetComponent<MeshRenderer>().enabled = false;
            PlayerIndicator.GetComponent<MeshRenderer>().enabled = false;
            //Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Take_Damage(int damagetaken)
    {

        Current_Health -= damagetaken;
        healthBar.value = Current_Health;
        PainScream.Play();
        if (Current_Health <= 0)
        {
            
            Blood_Animation();
            gm.Turn_Order.Remove(gameObject);
            Instantiate(ragDoll, this.gameObject.transform.position, Quaternion.identity);
            DeathScream.Play();
            if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
            {
                gm.End_Game(false);
            }
            Destroy(gameObject);
            Debug.Log("Dead");
        }
        Blood_Animation();
        if (Current_Health < Max_Health/2)
        {
            gameObject.GetComponent<PlayerMovement>().Set_Wounded_Idle();
        }
    }

    public void Blood_Animation()
    {
        blood.Play();
        
        
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

    public void Switch_Action()
    {
        if (Is_Attacking)
        {
            Is_Attacking = !Is_Attacking;
            Action_Range_Indicator.transform.localScale = new Vector3(Move_Range*2, 0, Move_Range*2);
            Action_Range_Indicator.GetComponent<MeshRenderer>().material = Move_Circle;
        }
        else
        {
            Is_Attacking = !Is_Attacking;
            Action_Range_Indicator.transform.localScale = new Vector3(Shoot_Range * 2, 0, Shoot_Range * 2);
            Action_Range_Indicator.GetComponent<MeshRenderer>().material = Attack_Circle;
        }
        
    }
}
   

