using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTriggerOut : MonoBehaviour
{
    public RockTrigger rockTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        rockTrigger.isEnteredCave = false;
    }
}
