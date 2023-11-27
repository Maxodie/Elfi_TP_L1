using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DoorScript : MonoBehaviour
{
    Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioReverbZone audioReverbZone;

    void Start()
    {
        audioReverbZone.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        audioReverbZone.gameObject.SetActive(true);
        audioSource.Play();
        animator.SetBool("In", true);
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.Play();
        animator.SetBool("In", false);
        if (!audioSource.isPlaying)
            audioReverbZone.gameObject.SetActive(false);
    }
}
