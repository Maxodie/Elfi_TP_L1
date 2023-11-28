using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    public bool isEnteredCave = false;

    private void OnTriggerEnter(Collider other)
    {
        isEnteredCave = true;
    }
}
