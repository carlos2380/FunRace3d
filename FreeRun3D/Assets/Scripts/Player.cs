using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private bool isRotation;
    private float speedRotation;
    // Start is called before the first frame update
    void Start()
    {
        isRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (isRotation == true)
            {
                transform.Rotate(0, speedRotation * Time.deltaTime, 0);
            }
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RotationPlayer")
        {
            speedRotation = other.GetComponent<CtrlRotationPlayer>().rotationSpeedPlayer;
            isRotation = true;
        }else if (other.gameObject.tag == "StopRotation")
        {
            speedRotation = 0f;
            isRotation = false;
        }
    }
}

