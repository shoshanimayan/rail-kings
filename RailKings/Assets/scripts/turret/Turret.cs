using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gun1;
    public GameObject gun2;
    public GameObject enemyBullet;
    private GameObject spawnPoint;
    public float distance = 7f;
    float timer = 0;
    private LayerMask IgnoreMe= ~(1 << 10);

    private void Start()
    {
        spawnPoint = gun1;
    }

    void ChangeGun()
    {

        if (spawnPoint == gun1)
            spawnPoint = gun2;
        else
            spawnPoint = gun1;
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,Camera.main.transform.position)<=distance && GameManager.playing)
        {
       
            if (timer<= 0)
            {
                Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponent<Rigidbody>().AddForce(gun1.transform.forward * 1000f);
                timer = 1f;
                ChangeGun();
            }
            else
                timer -= Time.deltaTime;
            
        }

    }
}
