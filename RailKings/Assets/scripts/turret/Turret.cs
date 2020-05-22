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
        RaycastHit hit;
       // if (Physics.Raycast(gun1.transform.position,Vector3.forward,out hit,IgnoreMe))
        if(Vector3.Distance(transform.position,Camera.main.transform.position)<=distance)
        {
            // Debug.Log(hit.transform.tag);

            // if (hit.transform.tag == "Player")
            // {
            if (timer<= 0)
            {
                Debug.Log("shoot");
                Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponent<Rigidbody>().AddForce(gun1.transform.forward * 100f);
                timer = 2f;
                ChangeGun();
            }
            else
                timer -= Time.deltaTime;
            //}
        }

    }
}
