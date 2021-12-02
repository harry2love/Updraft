using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CA_LookAround : MonoBehaviour
{
    private Transform player;
    public Vector2 rotation;
    [SerializeField]private float sensitivity;
    [SerializeField]private float offset;

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

        if(rotation.x < 90 && rotation.x > -90)
        {

        }
        else if(rotation.x > 90)
        {
            rotation.x = 90;
        }
        else if(rotation.x < -90)
        {
            rotation.x = -90;
        }

    }
}
