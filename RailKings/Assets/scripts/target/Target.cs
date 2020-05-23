using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject death;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "gun")
        {
            GameManager.points++; 
            Instantiate(death, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
