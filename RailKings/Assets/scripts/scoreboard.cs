using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreboard : MonoBehaviour
{
    public Text board;
    void Update()
    {
        board.text = "Score: ";//+GameManager.points.ToString();
    }
}
