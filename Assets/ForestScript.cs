using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestScript : MonoBehaviour
{
    [SerializeField] private List<AudioSource> audioSources;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (var audioSource in audioSources)
            audioSource.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var audioSource in audioSources)
        {
            Debug.Log("Created and playing");
            audioSource.gameObject.SetActive(true);
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var audioSource in audioSources)
        {
            Debug.Log("Destroyed");
            audioSource.gameObject.SetActive(false);
        }
    }
}
