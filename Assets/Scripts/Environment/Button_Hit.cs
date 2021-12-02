using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Hit : MonoBehaviour
{
    [SerializeField] private bool twoWay;
    [SerializeField] private string objectName;
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private Plat_Move.Direction direction;
    [SerializeField] private float pressTime;
    [SerializeField] private float pressDistance;

    private bool isPressed = false;
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
        switch (isPressed)
        {
            case false:
                GameObject.Find(objectName).GetComponent<Plat_Move>().Move(speed, distance, direction);
                StartCoroutine(PressEffect());
                break;
            case true:
                break;
        }
        
    }

    IEnumerator PressEffect()
    {
        isPressed = true;

        transform.Translate(new Vector3(0, 0, pressDistance));
        yield return new WaitForSeconds(pressTime);
        transform.Translate(new Vector3(0, 0, -pressDistance));

        isPressed = false;

        if (twoWay)
        {

            switch (direction)
            {
                case Plat_Move.Direction.Forward:
                    direction = Plat_Move.Direction.Backward;
                    break;

                case Plat_Move.Direction.Backward:
                    direction = Plat_Move.Direction.Forward;
                    break;

                case Plat_Move.Direction.Up:
                    direction = Plat_Move.Direction.Down;
                    break;

                case Plat_Move.Direction.Down:
                    direction = Plat_Move.Direction.Up;
                    break;

                case Plat_Move.Direction.Left:
                    direction = Plat_Move.Direction.Right;
                    break;

                case Plat_Move.Direction.Right:
                    direction = Plat_Move.Direction.Left;
                    break;
            }
        }
    }

}
