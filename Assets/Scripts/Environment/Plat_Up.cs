using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_Up : MonoBehaviour
{
    private bool start = false;
    private float speed;
    private float limit;
    // Start is called before the first frame update
    void Start()
    {
        GoUp(10, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (start && transform.position.y < limit)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

    public void GoUp(float speed, float limit)
    {
        start = true;
        this.speed = speed;
        this.limit = limit;
    }
}
