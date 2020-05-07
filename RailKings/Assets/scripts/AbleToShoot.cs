using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AbleToShoot : MonoBehaviour
{
    public bool colliding=false;
    public bool toFar = false;
    public GameObject stopSign;
    public GameObject rayCaster;
    private void Awake()
    {
        stopSign.SetActive(false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, rayCaster.transform.position) > 2f)
        {
            toFar = true;
        }
        else
        {
            toFar = false;
        }
        if (colliding || toFar)
        {
            stopSign.SetActive(true);
        }
        else
        {
            stopSign.SetActive(false);
        }
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "wall" ) {
            colliding = true;

        }
        if (collision.transform.tag == "obsticle")
        {
            GameManager.playing = false;
            colliding = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag =="wall")
        {
            colliding = true;
        }
      
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "wall")
        {
            colliding = false;
        }
        
    }
}
