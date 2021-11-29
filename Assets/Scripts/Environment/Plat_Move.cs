using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_Move : MonoBehaviour
{
    public enum Direction { Left, Right, Up, Down,Forward, Backward, None}
    public Direction direction;
    private float speed;
    private float limit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == Direction.Left && transform.position.x > limit)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        else if (direction == Direction.Right && transform.position.x < limit)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        else if (direction == Direction.Up && transform.position.y < limit)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        else if (direction == Direction.Down && transform.position.y > limit)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        else if(direction == Direction.Forward && transform.position.z < limit)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        else if(direction == Direction.Backward && transform.position.z > limit)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    public void GoSideWays(float speed, float limit, Direction direction)
    {
        this.direction = direction;
        this.speed = speed;
        this.limit = limit;
    }
}
