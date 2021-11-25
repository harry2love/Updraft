using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CA_Shoot : MonoBehaviour
{
    private Camera cam;

    private float range = 50;

    private int damage = 10;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1.2f));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, range))
            {
                if (hit.collider.GetComponent<Button_Hit>() != null && gameObject.name != "Player")
                {
                    hit.collider.GetComponent<Button_Hit>().Activate();
                }

                else if(hit.collider.GetComponent<BHit_Side>() != null && gameObject.name != "Player")
                {
                    hit.collider.GetComponent<BHit_Side>().Activate();
                }
            }
        }
    }
}
