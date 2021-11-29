using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Hit : MonoBehaviour
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
        GameObject.Find("Wall").GetComponent<Plat_Up>().GoUp(10, 5);
        StartCoroutine(PressEffect());
    }

    IEnumerator PressEffect()
    {
        transform.position -= new Vector3(0, transform.position.y - 0.5f, 0);
        yield return new WaitForSeconds(0.75f);
        transform.position += new Vector3(0, transform.position.y + 0.5f , 0);
    }
}
