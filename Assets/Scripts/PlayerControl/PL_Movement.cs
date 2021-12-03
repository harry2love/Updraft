using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_Movement : MonoBehaviour
{
    private float forwardSpeed = 10000;
    private float upwardForce = 2000;
    private float backForce = 10000;
    private float dashSpeed = 10000;

    private bool isGrounded = false;
    private bool dashActive = false;

    public Vector3 direction1;
    public Vector3 direction2;
    public Vector3 direction3;
    public Vector3 direction4;

    private Rigidbody rb;

    private enum keyboardLayout { AZERTY, QWERTY};
    [SerializeField] private keyboardLayout layout = keyboardLayout.AZERTY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (layout)
        {
            case keyboardLayout.AZERTY:

                if (Input.GetKey(KeyCode.Z))
                {
                    direction1 = transform.TransformDirection(Vector3.forward * Time.deltaTime * forwardSpeed);
                }
                else if (!Input.GetKey(KeyCode.Z))
                {
                    direction1 = new Vector3(0, 0, 0);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    direction2 = transform.TransformDirection(Vector3.back * Time.deltaTime * backForce);
                }
                else if (!Input.GetKey(KeyCode.S))
                {
                    direction2 = new Vector3(0, 0, 0);
                }

                if (Input.GetKey(KeyCode.Q))
                {
                    direction3 = transform.TransformDirection(Vector3.left * Time.deltaTime * forwardSpeed);
                }
                else if (!Input.GetKey(KeyCode.Q))
                {
                    direction3 = new Vector3(0, 0, 0);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    direction4 = transform.TransformDirection(Vector3.right * Time.deltaTime * forwardSpeed);
                }
                else if (!Input.GetKey(KeyCode.D))
                {
                    direction4 = new Vector3(0, 0, 0);
                }

                if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                {
                    rb.AddForce(Vector3.up * Time.deltaTime * upwardForce, ForceMode.Impulse);
                    isGrounded = false;
                }
                Vector3 fulldirection = direction1 + direction2 + direction3 + direction4;
                rb.velocity = new Vector3(fulldirection.x, rb.velocity.y, fulldirection.z);

                break;

            case keyboardLayout.QWERTY:

                if (layout == keyboardLayout.QWERTY)
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

                break;
        }

         
        if (!Input.anyKey)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
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
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Jumpable")
        {
            isGrounded = false;
        }
    }
}
