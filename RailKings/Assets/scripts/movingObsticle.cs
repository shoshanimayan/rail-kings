using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObsticle : MonoBehaviour
{
    private GameObject playerObj = null;
    private bool searching = true;
    public float height;
    // Start is called before the first frame update
    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("MainCamera");

    }
    // Update is called once per frame
    void Update()
    {
        if (searching)
        {
            if (Vector3.Distance(transform.position, playerObj.transform.position) < 5)
            {
                searching = false;
            }
        }
        else {
            if (transform.position.y >= height)
                transform.Translate(transform.up * -1 * Time.deltaTime);
        }

    }
}
