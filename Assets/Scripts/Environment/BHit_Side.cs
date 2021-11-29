using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHit_Side : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate()
    {
        StartCoroutine(PressEffect());

        if (GameObject.Find("PlatForm").transform.position.x > 3)
        {
            GameObject.Find("PlatForm").GetComponent<Plat_Side>().GoSideWays(10, -6);
        }

        else if (GameObject.Find("PlatForm").transform.position.x < 4)
        {
            GameObject.Find("PlatForm").GetComponent<Plat_Side>().GoSideWays(-10, 4);
        }
    }

    IEnumerator PressEffect()
    {
        transform.position -= new Vector3(0, transform.position.y - 0.5f, 0);
        yield return new WaitForSeconds(2);
        transform.position += new Vector3(0, transform.position.y + 0.5f, 0);
    }
}
