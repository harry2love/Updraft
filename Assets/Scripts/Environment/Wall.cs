using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if((player.position - transform.position).sqrMagnitude < 5)
        {

        }
    }
}
