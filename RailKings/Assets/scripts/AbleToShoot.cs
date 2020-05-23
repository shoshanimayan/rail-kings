using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public class AbleToShoot : MonoBehaviour
{
    public bool colliding=false;
    public bool toFar = false;
    public GameObject bloodUI;
    public GameObject stopSign;
    public GameObject gameOverSign;
    public GameObject rayCaster;
    private void Awake()
    {
        bloodUI.SetActive(false);
        stopSign.SetActive(false);
        gameOverSign.SetActive(false);
    }

    IEnumerator BloodDamage() {
        yield return new  WaitForSeconds(.5f);
        bloodUI.SetActive(false);
    }
    private void Update()
    {
        if (GameManager.playing)
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
        else {
            gameOverSign.SetActive(true);
           
                }
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.tag == "wall" ) {
            colliding = true;

        }
        if (collision.transform.tag == "obstacle")
        {
            GameManager.health -= 3;
            bloodUI.SetActive(true);
        }
        if (collision.transform.tag == "enemy")
        {
            GameManager.health -= 1;
            bloodUI.SetActive(true);
            StartCoroutine(BloodDamage());
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
