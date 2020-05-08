using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AmmoShell : MonoBehaviour
{
    float time = 0;

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 5f)
            Destroy(gameObject);
    }
}
