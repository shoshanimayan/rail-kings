using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    public void damage(int hit) {
        health -= hit;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "gun")
            damage(1);

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { Destroy(gameObject); }
    }
}
