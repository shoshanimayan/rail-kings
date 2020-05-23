using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "gun" &&collision.gameObject.tag != "MainCamera")
        {
            Debug.Log(collision.transform.tag);

            Destroy(gameObject);
        }
    }
}
