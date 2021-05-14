using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowObjectives : MonoBehaviour
{
    [SerializeField]
    private GameObject Expanded_Objectives;
    [SerializeField]
    private GameObject Minimized_Objectives;

    // Start is called before the first frame update
    void Toggle_Objectives()
    {
        if(Expanded_Objectives.activeSelf)
        {
            Expanded_Objectives.SetActive(false);
            Minimized_Objectives.SetActive(true);
        }
        else
        {
            Expanded_Objectives.SetActive(true);
            Minimized_Objectives.SetActive(false);
        }
    }
}
