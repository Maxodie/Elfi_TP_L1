using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioReverbZone reverbZone;
    void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;
        reverbZone.gameObject.SetActive(true);
        audioSource.Play();
    }

    void OnTriggerExit(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;
        audioSource.Stop();
        reverbZone.gameObject.SetActive(false);
    }
}