using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CA_LookAround : MonoBehaviour
{
    private Transform player;
    private Vector2 rotation;
    private float sensitivity = 5;
    private float offset = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y = rotation.y + Input.GetAxis("Mouse X");
        rotation.x -= Input.GetAxis("Mouse Y");

        transform.position = player.position + new Vector3(0, offset, 0);
        transform.eulerAngles = rotation * sensitivity;
        player.eulerAngles = new Vector2(player.rotation.x, rotation.y) * sensitivity;
    }
}
