using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollow : MonoBehaviour
{
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
      //  transform.forward = Vector3.ProjectOnPlane((Camera.main.transform.position - transform.position), Vector3.up).normalized;
    }
}
