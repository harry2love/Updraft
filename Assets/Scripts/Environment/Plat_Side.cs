using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_Side : MonoBehaviour
{
    private bool start = false;
    private float limit;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (start && transform.position.x > limit)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    public void GoSideWays(float speed, float limit)
    {
        start = true;
        this.speed = speed;
        this.limit = limit;
    }
}
