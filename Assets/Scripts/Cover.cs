using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    public Animator animator;
    public Transform gfx;
    private GameObject player;
    private PlayerMovement playerMovement;

    private void Start()
    {
        player = this.transform.parent.gameObject;
        playerMovement = player.GetComponent<PlayerMovement>();
        gfx = player.transform.GetChild(0);
        animator = gfx.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("In cover");
            animator.SetBool("isCrouched", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("Left Cover");
            animator.SetBool("isCrouched", false);
        }
    }
}