using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_Movement : MonoBehaviour
{
    private float forwardSpeed = 10;
    private float upwardForce = 1300;
    private float backForce = 5;
    private bool isGrounded = false;

    private Rigidbody rb;

    private enum keyboardLayout { AZERTY, QWERTY};
    private keyboardLayout layout = keyboardLayout.AZERTY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(layout == keyboardLayout.AZERTY)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.deltaTime * backForce);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(Vector3.left * Time.deltaTime * forwardSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * forwardSpeed);
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * Time.deltaTime * upwardForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        else if(layout == keyboardLayout.QWERTY)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.back * Time.deltaTime * backForce);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.left * Time.deltaTime * forwardSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * forwardSpeed);
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * Time.deltaTime * upwardForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Jumpable")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Jumpable")
        {
            isGrounded = false;
        }
    }
}
