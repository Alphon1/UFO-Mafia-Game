using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyColourChange : MonoBehaviour
{
    public Material baseMaterial;
    public Material highlightedColour;

    public void OnMouseOver()
    {

        GetComponent<Renderer>().material = highlightedColour;

    }
    public void OnMouseExit()
     {

            GetComponent<Renderer>().material = baseMaterial;
     }

     
}

