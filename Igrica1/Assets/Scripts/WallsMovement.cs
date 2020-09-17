using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMovement : MonoBehaviour
{
    private Transform trans;
    private float timer = 5f;
    private Vector3 movementVector = new Vector3(0, 0, 1);
    public float speed = 1f;
    public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        move(trans, movementVector);
    }

    public void move(Transform trans, Vector3 movementVector)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            timer = 5f;
            direction = -direction;
        }
        trans.position += movementVector * speed * Time.deltaTime * direction;
    }

    public Vector3 movementSpeed()
    {
        return movementVector * speed * Time.deltaTime * direction;
        //return new Vector3(1, 1, 1);
    }
}
