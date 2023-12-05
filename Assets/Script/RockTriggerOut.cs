using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTriggerOut : MonoBehaviour
{
    public RockTrigger rockTrigger;
    public List<AudioSource> ambiantAudioSources;
    
    private void OnTriggerEnter(Collider other)
    {
        rockTrigger.isEnteredCave = false;

        foreach (var audioSource in ambiantAudioSources)
        {
            Debug.Log("prout");
            audioSource.Stop();
        }
    }
}
