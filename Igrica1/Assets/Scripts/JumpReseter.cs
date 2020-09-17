using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpReseter : MonoBehaviour
{
    Rigidbody rb;
    public static bool frozen;
    public static float timer;
    public GameObject wall;
    private Vector3 movementVector = new Vector3(0, 0, 1);
    private Vector3 offset;
    private Vector3 lastPosition;
    public static bool onTop;
    private bool playingMusic = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        frozen = false;
        timer = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collisionTag = collision.gameObject.tag;
        string collisionName = collision.gameObject.name;
        //Debug.Log(collision.gameObject.name);
        //BoxCollider wallCollider = wall.GetComponent<BoxCollider>();
        //if (collisionTag == "Wall" & timer == 0 & collisionName != "Top Layer")
        //{
        //    //rb.transform.position = collision.transform.position;
        //    frozen = true;
        //    //animator.SetBool("OnWall", true);
        //    wall = collision.gameObject;
        //    //wallCollider.size = new Vector3(2 * wallCollider.size.x, wallCollider.size.y, wallCollider.size.z);
        //    offset = wall.transform.position - rb.transform.position;
        //    lastPosition = rb.transform.position;
        //    GetComponent<CapsuleCollider>().isTrigger = true;
        //    //Debug.Log(offset + " " + wall.transform.position);
        //}
        if (collisionTag == "Lava" || collisionTag == "Enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (collisionTag == "Untagged" && collisionName == "Top Layer")
        {
            onTop = true;
        }
        else if (collisionTag == "End")
        {
            PlayerMovement.onGround = true;
            animator.SetBool("Jump", false);
            collision.gameObject.GetComponent<ConfettiTrigger>().CreateConfetti();
            if (!playingMusic)
            {
                collision.gameObject.GetComponent<AudioSource>().Play();
                GameObject.Find("MusicCoolio").GetComponent<AudioSource>().mute = true;
                playingMusic = true;
            }
        }

        if (timer == 0 & collisionTag != "Enemy" & collisionTag != "Lava")
        {
            PlayerMovement.onGround = true;
            animator.SetBool("Jump", false);
        }

    }
    void Update()
    {
        //if (Input.GetKeyDown("t"))
        //    Debug.Log(rb.velocity);
        
        if (timer > 0)
            timer -= Time.deltaTime;
        if (timer < 0)
            timer = 0;
    }

}
