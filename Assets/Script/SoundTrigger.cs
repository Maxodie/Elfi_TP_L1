using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {
    [SerializeField] AudioSource audioSource;
    void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Player")
            audioSource.Play();
    }

    void OnTriggerExxit(Collider collider) {
        if(collider.tag == "Player")
            audioSource.Stop();
    }

}