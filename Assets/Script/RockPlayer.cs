using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockPlayer : MonoBehaviour
{

    [SerializeField] private List<AudioSource> rockSpeakers;
    [SerializeField] private List<AudioClip> rockSounds;
    [SerializeField] private float soundOffset;
    
    public RockTrigger rockTrigger;
    private float countdown;

    public void Update()
    {
        if (rockTrigger.isEnteredCave)
        {
            if (countdown <= 0f)
            {
                rockSpeakers[Random.Range(0,rockSpeakers.Count)].PlayOneShot(rockSounds[Random.Range(0,rockSounds.Count)]);
                countdown = soundOffset;
            }
            else
            {
                countdown -= Time.deltaTime;
            }
            
        }
    }
    
}
