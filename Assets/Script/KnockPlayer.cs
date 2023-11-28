using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnockPlayer : MonoBehaviour
{

    [SerializeField] private List<AudioSource> knockSpeaker;
    [SerializeField] private List<AudioClip> knockSound;
    [SerializeField] private float soundOffset;
    private float countdown;

    public DoorScript doorScript;

    public void Update()
    {
        if (doorScript.isEnteredMansion)
        {
            if (countdown <= 0f)
            {
                knockSpeaker[Random.Range(0,knockSpeaker.Count)].PlayOneShot(knockSound[Random.Range(0,4)]);
                countdown = soundOffset;
            }
            else
            {
                countdown -= Time.deltaTime;
            }
            
        }
    }
    
}
