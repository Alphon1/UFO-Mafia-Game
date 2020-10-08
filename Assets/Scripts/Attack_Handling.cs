using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Handling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //sends a ray from the camera to where the mouse clicked
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if the ray hits an enemy, calls the attack
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy")
        {
          //  Friendly_Attack(, hit, );
        }
    }

    public void Friendly_Attack(GameObject Current_Character, GameObject Target, float Weapon_Range)
    {
        //checks if there's nothing in the way of the attack
        if(Physics.Linecast(Current_Character.transform.position, Target.transform.position))
        {
            //checks if the selected enemy is in range
            if(Vector3.Distance(Current_Character.transform.position, Target.transform.position) < Weapon_Range)
            {

            }
        }
    }
}
