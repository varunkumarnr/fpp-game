using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip Scream_Clip, Die_Clip;
    [SerializeField]
    private AudioClip[] Attack_Clip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Play_ScreamSound()
    {
        audioSource.clip = Scream_Clip;
        audioSource.Play();
    }
    public void Play_AttackSound()
    {
        audioSource.clip = Attack_Clip[Random.Range(0, Attack_Clip.Length)];
        audioSource.Play();
    }
    public void Play_DeathSound()
    {
        audioSource.clip = Die_Clip;
        audioSource.Play();
    }
}
