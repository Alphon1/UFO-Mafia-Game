using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skillTree;
    public bool isSkillTree;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isSkillTree)
            {
                ResumeGame();

            }
            else
            {
                isSkillTree = true;
                skillTree.SetActive(true);
            }
        }





    }

    public void ResumeGame()
    {
        isSkillTree = false;
        skillTree.SetActive(false);

    }
}

