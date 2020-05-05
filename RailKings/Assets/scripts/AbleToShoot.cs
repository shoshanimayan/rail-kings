using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbleToShoot : MonoBehaviour
{
    public bool colliding=false;
    public GameObject stopSign;

    private void Awake()
    {
        stopSign.SetActive(false);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "wall" ) {
            colliding = true;
            stopSign.SetActive(true);

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
            stopSign.SetActive(false);
        }
        
    }
}
