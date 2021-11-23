using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAbility : MonoBehaviour
{
    public GameObject cloud;
    private float offset = 1.5f;
    private int uses = 5;
    private int bundle = 1;
    private int cap = 5;
    private float reload = 2;

    private bool reloadActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && uses != 0)
        {
            Instantiate(cloud, transform.position + new Vector3(0, -offset, 0), new Quaternion(0, 0, 0, 0));
            uses -= 1;
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        if (!reloadActive)
        {
            reloadActive = true;
            yield return new WaitForSeconds(reload);
            uses += bundle;
            reloadActive = false;
        }
        if(uses < cap && !reloadActive)
        {
            StartCoroutine(Reload());
        }
    }
}
