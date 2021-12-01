using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CA_LookAround : MonoBehaviour
{
    private Transform player;
    private Vector2 rotation;
    private float sensitivity = 1;
    private float offset = 0.45f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

            rotation.x -= Input.GetAxis("Mouse Y");
        rotation.y = rotation.y + Input.GetAxis("Mouse X");
        

        transform.position = player.position + new Vector3(0, offset, 0);
        transform.eulerAngles = rotation * sensitivity;
        player.eulerAngles = new Vector2(player.rotation.x, rotation.y) * sensitivity;

        /*if (localAngle.x > 180 && localAngle.x > -180)
        {
            Debug.Log("Quoi?");
            transform.localRotation = new Quaternion(180, localAngle.y, localAngle.z, transform.localRotation.w);
        }
        else if(localAngle.x < -90 && localAngle.x < 90)
        {
            transform.localRotation = new Quaternion(-90, localAngle.y, localAngle.z, transform.localRotation.w);
        }*/ //werkt niet

    }
}
