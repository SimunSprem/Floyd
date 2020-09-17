using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementCircular : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1f;
    public float radius = 20f;
    public float delay;

    private Vector3 fixedPoint;
    private float currentAngle = 3f;
    private int direction = 1;
    private float timer = 2 * Mathf.PI;
       
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fixedPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
                timer = Mathf.PI * 2;
                direction = -direction;
            }

            currentAngle += speed * Time.deltaTime * direction;
            Vector3 offset = new Vector3(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle), 0) * radius;
            transform.position = fixedPoint + offset;
        }
        else
            delay -= Time.deltaTime;

    }
}
