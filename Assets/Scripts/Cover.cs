using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cover")
        {
            other.tag = "!Cover";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "!Cover")
        {
            other.tag = "Cover";
        }
    }
}
