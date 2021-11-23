using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAbility : MonoBehaviour
{
    public GameObject cloud;
    private float offset = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Instantiate(cloud, transform.position + new Vector3(0, -offset, 0), new Quaternion(0, 0, 0, 0));
        }
    }
}
