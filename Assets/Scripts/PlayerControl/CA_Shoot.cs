using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CA_Shoot : MonoBehaviour
{
    private float weaponRange = 500;
    private Camera camera;
    private float fireRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hit;

            if(Physics.Raycast(rayOrigin, camera.transform.forward, out hit, weaponRange))
            {
                if(hit.transform.name == "Cloud(Clone)")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
