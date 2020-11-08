using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float timeDeading;

    private bool isRotation;
    private float speedRotation;
    private Rigidbody rigidbody;
    private Vector3 positionCheckpoint;
    private Quaternion rotationCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        isRotation = false;
        rigidbody = GetComponent<Rigidbody>();
        positionCheckpoint = transform.position;
        rotationCheckpoint = transform.rotation;
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

    void checkpoint()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        rigidbody.useGravity = false;
        rigidbody.mass = 1;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        transform.position = positionCheckpoint;
        transform.rotation = rotationCheckpoint;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RotationPlayer")
        {
            speedRotation = other.GetComponent<CtrlRotationPlayer>().rotationSpeedPlayer;
            isRotation = true;
        }
        else if (other.gameObject.tag == "StopRotation")
        {
            speedRotation = 0f;
            isRotation = false;
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("DEAAAAD");
            rigidbody.constraints = 0;
            rigidbody.useGravity = true;
            rigidbody.mass = 10;
            rigidbody.AddForce(rigidbody.velocity * 100f);
            StartCoroutine(deading());
        }

        IEnumerator deading()
        {
            yield return new WaitForSeconds(timeDeading);
            checkpoint();
        }
    }
}

