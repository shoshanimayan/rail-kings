using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
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
        if (collision.gameObject.tag != "enemy")
        {

            Destroy(gameObject);
        }
    }
}
