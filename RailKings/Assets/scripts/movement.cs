using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using PathCreation;
public class movement : MonoBehaviour
{
    private bool forward;
    public float gravityMultiplier = 1f;
    public float speed = 2f;
    public GameObject rig ;
    public GameObject head;
    public bool colliding;
    public PathCreator pathCreator;
    private float distanceTravelled;
    //spline


    public void Forward() { forward = true;  }
    void Start()
    {
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
        forward =false;
        colliding = false;
    }

    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
    private void ApplyGravity() {
        rig.transform.Translate(transform.up * -1*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.playing)
        {
            //check if wall infront of you
            RaycastHit hit;
            Vector3 p1 = transform.position + Vector3.up * 0.25f;
            if (Physics.Raycast(p1, Vector3.forward, out hit, .5f))
            {
                if (hit.transform.tag == "wall") { forward = false; }

            }

            //no falling, 
            //if not colliding and moving forward follow camera, but not off bounds
            if (head.transform.position.x > -1.28f && head.transform.position.x < 1.28f)
            {
                transform.position = new Vector3(head.transform.position.x, transform.position.y, transform.position.z);
            }


            if (!colliding && forward)
            {
                distanceTravelled += speed * Time.deltaTime;
                rig.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Loop);
            }
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
