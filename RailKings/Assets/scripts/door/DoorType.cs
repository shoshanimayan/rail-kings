using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorType : MonoBehaviour
{
    public enum Door {normal,exit,next,menu }
    public Door door;
    // Update is called once per frame
    public void DoorAction() {
        switch (door) {
            case( Door.normal):
                break;
            default:
                break;
        }
    }
}
