using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float rotY;
    public float rotationSpeed = 10;

    public Vector3 offset;
    void Start()
    {
        offset = new Vector3(0, 6, 20);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown("r"))
            transform.Rotate(0, 180, 0);
        if (Input.GetKeyUp("r"))
            transform.Rotate(0, 180, 0);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }

    private void Update()
    {
        
    }
}
