using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlCamera : MonoBehaviour
{
    public Camera cam;
    public Animator animator;

    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Roulette")
        {
            animator.SetTrigger("Roulette");
        }else if (other.gameObject.tag == "Finish")
        {
            animator.SetTrigger("End");
        }

    }
}
