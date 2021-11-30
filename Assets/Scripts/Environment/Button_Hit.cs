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
        GameObject.Find("PlatForm").GetComponent<Plat_Move>().Move(speed, distance, direction);
        StartCoroutine(PressEffect());
    }

    IEnumerator PressEffect()
    {
        transform.position -= new Vector3(0, transform.position.y - 0.5f, 0);
        yield return new WaitForSeconds(0.75f);
        transform.position += new Vector3(0, transform.position.y + 0.5f , 0);

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
