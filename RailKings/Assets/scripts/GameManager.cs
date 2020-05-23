using Oculus.Platform.Samples.VrHoops;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static bool playing = true;
    public static int points = 0;
    public static int health = 3;
    // Start is called before the first frame update

    private void Awake()
    {
        health = 3;
        points = 0;
        playing = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            playing = false;
            Debug.Log("dead");
        }
        if (!playing) {
            if (Input.anyKeyDown)
                SceneManager.LoadScene(0);
        } 
    }

}
