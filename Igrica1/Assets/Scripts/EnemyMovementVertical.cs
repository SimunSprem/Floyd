using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementVertical : MonoBehaviour
{
    Rigidbody rb;
    float timer = 5f;
    public float force = 30;
    public float BONUS_GRAV = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, BONUS_GRAV, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "JumpReseterPlane")
            rb.AddForce(0, force, 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
