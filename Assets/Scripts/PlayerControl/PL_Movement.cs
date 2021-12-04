using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_Movement : MonoBehaviour
{
    private float speed = 10;
    private float upwardForce = 2;
    private float backSpeed = 10;
    private float dashSpeed = 10;

    private bool isGrounded = false;
    private bool dashActive = false;

    private Vector3 direction1;
    private Vector3 direction2;
    private Vector3 direction3;
    private Vector3 direction4;

    private Rigidbody rb;

    private enum keyboardLayout { AZERTY, QWERTY};
    [SerializeField] private keyboardLayout layout = keyboardLayout.AZERTY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (layout)
        {
            case keyboardLayout.AZERTY:

                if (Input.GetKey(KeyCode.Z))
                {
                    direction1 = transform.TransformDirection(Vector3.forward * Time.deltaTime * speed * 100);
                }
                else if (!Input.GetKey(KeyCode.Z))
                {
                    direction1 = new Vector3(0, 0, 0);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    direction2 = transform.TransformDirection(Vector3.back * Time.deltaTime * backSpeed * 100);
                }
                else if (!Input.GetKey(KeyCode.S))
                {
                    direction2 = new Vector3(0, 0, 0);
                }

                if (Input.GetKey(KeyCode.Q))
                {
                    direction3 = transform.TransformDirection(Vector3.left * Time.deltaTime * speed * 100);
                }
                else if (!Input.GetKey(KeyCode.Q))
                {
                    direction3 = new Vector3(0, 0, 0);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    direction4 = transform.TransformDirection(Vector3.right * Time.deltaTime * speed * 100);
                }
                else if (!Input.GetKey(KeyCode.D))
                {
                    direction4 = new Vector3(0, 0, 0);
                }

                if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                {
                    rb.AddForce(Vector3.up * Time.deltaTime * upwardForce * 1000, ForceMode.Impulse);
                    isGrounded = false;
                }
                Vector3 fulldirection = direction1 + direction2 + direction3 + direction4;
                rb.AddForce(new Vector3(fulldirection.x, rb.velocity.y, fulldirection.z));

                if(rb.velocity.x > 50)
                {
                    rb.velocity = new Vector3(90, rb.velocity.y, rb.velocity.z);
                }
                else if(rb.velocity.z > 50)
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 90);
                }

                break;

            case keyboardLayout.QWERTY:

                if (layout == keyboardLayout.QWERTY)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        transform.Translate(Vector3.back * Time.deltaTime * backSpeed);
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * speed);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * speed);
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
