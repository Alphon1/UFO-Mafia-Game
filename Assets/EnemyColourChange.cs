using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColourChange : MonoBehaviour
{
    public Color baseColour;
    public Color highlightedColour;
    bool mouseOver = false;
    void OnMouseEnter()
    {
        mouseOver = true;
        GetComponent<Renderer>().material.SetColor("_Colour", highlightedColour);
    }
    void OnMouseExit()
    {
        mouseOver = false;
        GetComponent<Renderer>().material.SetColor("_Colour", baseColour);
    }

}

