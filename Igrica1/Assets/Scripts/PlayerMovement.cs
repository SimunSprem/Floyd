using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraRotation;
    public float speed = 15f;
    public float jumpSpeed = 3f;
    public static bool onGround;
    public bool grounded;
    public float BONUS_GRAV = 1;
    public Animator animator;

    private Vector3 moveDirection;
    private Vector3 jump;
    private bool doubleJump;
    Rigidbody rb;
    CharacterController characterController;


    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 2, 0);
        characterController = GetComponent<CharacterController>();
        grounded = onGround;
        //doubleJump = true;
    }


    void Update()
    {
        grounded = onGround;
        //if (!onGround)
        //{
        Vector3 vel = rb.velocity;
        vel.y -= BONUS_GRAV * Time.deltaTime;
        rb.velocity = vel;
        //}
        //try
        //{
        //    transform.rotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y + 180, 0);
        //}
        //catch { }
        if (!FistCollision.frozen) //Mozes se kretat ako nisi smrznut
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                Debug.Log("Quit");
            }
            speed = 15;
            animator.SetBool("ShiftPressed", false);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed *= 2;
                animator.SetBool("ShiftPressed", true);
                Debug.Log(speed);
            }

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Speed", Mathf.Abs(h) + Mathf.Abs(v));

            moveDirection.Set(h, 0, v);
            moveDirection = -moveDirection.normalized * speed * Time.deltaTime;
            moveDirection = transform.worldToLocalMatrix.inverse * moveDirection;
             
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if (!JumpReseter.onTop)
                transform.position += moveDirection;
            else
            {
                Vector3 wallMovement;
                try
                {
                    wallMovement = GetComponent<JumpReseter>().wall.GetComponent<WallsMovement>().movementSpeed();
                }
                catch
                {
                    wallMovement = new Vector3(0, 0, 0);
                }
                //Debug.Log(GetComponent<JumpReseter>().wall.GetComponent<WallsMovement>().movementSpeed());
                transform.position += moveDirection + wallMovement;
            }
        }
        else
        {
            transform.position = FistCollision.wallWithOffsetPosition();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("OnWallLeft", false);
            animator.SetBool("OnWallRight", false);

            if (FistCollision.frozen)
            {
                FistCollision.frozen = false;
                rb.isKinematic = false;
                //GetComponent<CapsuleCollider>().isTrigger = false;
                FistCollision.timer = 0.2F;
            }
            if (onGround)
            {
                onGround = false;
                animator.SetBool("Jump", true);
                JumpReseter.onTop = false;
            }
            rb.velocity = jump * jumpSpeed;
            //Debug.Log(rb.velocity);
        }
    }

    //void DontGoThroughWall(Vector3 moveDir)
    //{
    //    GameObject wall;
    //    if (GetComponent<JumpReseter>().wall != null)
    //        wall = GetComponent<JumpReseter>().wall;
    //    if()
    //}
}
