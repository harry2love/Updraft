using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float destroyTime = 3;
    private float collisionDestroyTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private IEnumerator Die()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    private IEnumerator CollisionDeath()
    {
        yield return new WaitForSeconds(collisionDestroyTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(CollisionDeath());
        }
    }
}
