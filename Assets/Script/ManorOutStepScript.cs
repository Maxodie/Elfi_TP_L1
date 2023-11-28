using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManorOutStepScript : MonoBehaviour
{
    public DoorScript doorScript;
    
    private void OnTriggerEnter(Collider other)
    {
        doorScript.isEnteredMansion = false;
    }
}
