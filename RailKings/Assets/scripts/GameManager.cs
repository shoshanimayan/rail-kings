using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool playing;
    // Start is called before the first frame update
    void Awake()
    {
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing) { 
        //end game procedure
        
        } 
    }
}
