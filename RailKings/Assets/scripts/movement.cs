using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class movement : MonoBehaviour
{
    private bool forward;
    public float gravityMultiplier = 1f;
    public float speed = 2f;
    public GameObject rig ;
    public GameObject head;
    public bool colliding;


    void Start()
    {
        forward = true;
        colliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  PositionController();
        //  ApplyGravity();
     
        RaycastHit hit;

        //Bottom of controller. Slightly above ground so it doesn't bump into slanted platforms. (Adjust to your needs)
        Vector3 p1 = transform.position + Vector3.up * 0.25f;

        if (Physics.Raycast(p1, Vector3.forward, out hit, .5f))
        {
            if (hit.transform.tag == "wall") { forward = false; }
        }
        else {

            forward = true;
        }

        if (!colliding && forward)
        {
            transform.position = new Vector3(head.transform.position.x, transform.position.y, head.transform.position.z);
            rig.transform.Translate(transform.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.position = new Vector3(head.transform.position.x, transform.position.y, transform.position.z);

        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        colliding = true;

    }
    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

}
