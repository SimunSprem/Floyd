using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    private bool rightClicked = false;
    public float rotationSpeed = 100f;
    public Transform cameraRotation;

    void Start()
    {
    }
    void Update()
    {
        if (!FistCollision.frozen)
            transform.rotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y + 180, 0);
        //if (rightClicked)
        //{
        //    transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0);
        //    //transform.rotation += Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0);
        //}
        //transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0);
    }
}
