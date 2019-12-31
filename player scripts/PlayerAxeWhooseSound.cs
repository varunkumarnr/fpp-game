using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxeWhooseSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] Whoosh_Sounds;
    void PlayWhooshSound()
    {
        audioSource.clip = Whoosh_Sounds[Random.Range(0, Whoosh_Sounds.Length)];
        audioSource.Play();
    }

}
