using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistCollision : MonoBehaviour
{

    public static bool frozen = false;
    private static GameObject wall;
    GameObject player;
    private static Vector3 offset;
    public Animator animator;
    public static float timer;
    //SphereCollider sc;
    //CapsuleCollider cc;

    void Start()
    {
        timer = 0f;
        string parentName = transform.parent.name;
        player = transform.parent.parent.parent.parent.gameObject;
        Debug.Log(transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
            timer -= Time.deltaTime;
        if (timer < 0)
            timer = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        string collisionTag = collider.gameObject.tag;
        string collisionName = collider.gameObject.name;

        if (collisionTag == "Wall" & collisionName != "Top Layer" & timer == 0)
        {
            //Animacije
            animator.SetBool("Jump", false);
            if(transform.parent.name == "RightArm" || transform.parent.name == "RightLeg")
            {
                animator.SetBool("OnWallRight", true);
                timer = 0.2f;
            }
            else if(transform.parent.name == "LeftArm" || transform.parent.name == "LeftLeg")
            {
                animator.SetBool("OnWallLeft", true);
                timer = 0.2f;
            }
            
            frozen = true;
            wall = collider.gameObject;
            offset = wall.transform.position - player.transform.position;

            if(GetComponent<CapsuleCollider>())
                GetComponent<CapsuleCollider>().isTrigger = true;
            if(GetComponent<SphereCollider>())
                GetComponent<SphereCollider>().isTrigger = true;

            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    public static Vector3 wallWithOffsetPosition()
    {
        return wall.transform.position - offset;
    }
}
