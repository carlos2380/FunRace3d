using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlCamera : MonoBehaviour
{
    public Camera cam;
    public Animator animator;
    private Vector3 positionStart;
    private Quaternion rotationStart;

    void Start()
    {
        positionStart = cam.gameObject.transform.position;
        rotationStart = cam.gameObject.transform.rotation;
    }

    public void restart()
    {
        cam.gameObject.transform.position = positionStart;
        cam.gameObject.transform.rotation = rotationStart;
        animator.SetTrigger("Restart");
    }
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
