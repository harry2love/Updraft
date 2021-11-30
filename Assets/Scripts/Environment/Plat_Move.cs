using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_Move : MonoBehaviour
{
    public enum Direction { Left, Right, Up, Down,Forward, Backward, None}
    public Direction direction = Direction.None;

    private Vector3 currentPos;

    private float speed;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == Direction.Left && transform.position.x > currentPos.x - distance)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        else if (direction == Direction.Right && transform.position.x < currentPos.x + distance)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        else if (direction == Direction.Up && transform.position.y < currentPos.y + distance)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        else if (direction == Direction.Down && transform.position.y > currentPos.y - distance)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        else if(direction == Direction.Forward && transform.position.z < currentPos.z + distance)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        else if(direction == Direction.Backward && transform.position.z > currentPos.z - distance)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    public void Move(float speed, float distance, Direction direction)
    {
        currentPos = transform.position;
        this.direction = direction;
        this.speed = speed;
        this.distance = distance;
    }
}
