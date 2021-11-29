using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_Movement : MonoBehaviour
{
    private float forwardSpeed = 10;
    private float upwardForce = 2000;
    private float backForce = 5;
    private float climbSpeed = 10;
    private float dashSpeed = 10000;

    private bool isGrounded = false;
    private bool isAgainstWall = false;
    private bool dashActive = false;

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
            if (Input.GetKey(KeyCode.Z) && !isAgainstWall)
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
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isAgainstWall)
            {
                rb.AddForce(Vector3.up * Time.deltaTime * upwardForce, ForceMode.Impulse);
                isGrounded = false;
            }
            if(Input.GetKey(KeyCode.Space) && isAgainstWall)
            {
                transform.Translate(Vector3.up * Time.deltaTime * climbSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                StartCoroutine(Dash());
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

        if (dashActive)
        {
            rb.AddRelativeForce(Vector3.forward * Time.deltaTime * dashSpeed);
        }

    }

    IEnumerator Dash()
    {
        dashActive = true;
        yield return new WaitForSeconds(0.5f);
        dashActive = false;
        rb.velocity = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Jumpable")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "ClimbAble")
        {
            isAgainstWall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Jumpable")
        {
            isGrounded = false;
        }
        else if(collision.gameObject.tag == "ClimbAble")
        {
            isAgainstWall = false;
        }
    }
}
