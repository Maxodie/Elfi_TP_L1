using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantTrigger : MonoBehaviour {
    [SerializeField] private List<AudioSource> audioSources;
    [SerializeField] AudioReverbZone reverbZone;
    [SerializeField] private float soundOffset = 0f;
    
    void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;
        reverbZone.gameObject.SetActive(true);
        StartCoroutine(SoundOffset());
    }

    IEnumerator SoundOffset()
    {
        foreach (var audioSource in audioSources)
        {
            yield return new WaitForSeconds(soundOffset);
            audioSource.Play();
        }
    }
}