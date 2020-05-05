using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.tag != "gun" &&collision.gameObject.tag != "MainCamera")
        {
            Destroy(gameObject);
        }
    }
}
