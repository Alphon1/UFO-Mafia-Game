using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public GameObject missionBrief;
    // Start is called before the first frame update
    public void Start()
    {
        missionBrief.SetActive(false);
    }

     public void OnMouseOver()
        {
            missionBrief.SetActive(true);
        }


        public void OnMouseExit()
        {
            missionBrief.SetActive(false);

        }
     
}

