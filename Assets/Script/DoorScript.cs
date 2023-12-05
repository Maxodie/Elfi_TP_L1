using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DoorScript : MonoBehaviour
{
    public bool isEnteredMansion = false;
    
    Animator animator;
    CheckTerrainTextures PlayerCheckTerrainTextures;
    [SerializeField] private List<AudioSource> windAudioSources;
    
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
        isEnteredMansion = true;
        OnOffWindSounds();
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.Play();
        animator.SetBool("In", false);
        if (!audioSource.isPlaying)
            audioReverbZone.gameObject.SetActive(false);
    }

    public void OnOffWindSounds()
    {
        if (isEnteredMansion)
        {
            foreach (var audioSource in windAudioSources)
            {
                audioSource.Stop();
            }
        }

        if (!isEnteredMansion)
        {
            foreach (var audioSource in windAudioSources)
            {
                audioSource.Play();
            }
        }
    }
}
