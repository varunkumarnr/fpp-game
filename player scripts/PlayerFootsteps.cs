using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource footstep_Sound;
    [SerializeField]
    private AudioClip[] footstep_Clip;
    private CharacterController character_Controller;
    [HideInInspector]
    public float Volume_min, Volume_max;
    private float acummulate_distance;
    [HideInInspector]
    public float step_Distance;
    void Awake()
    {
        footstep_Sound = GetComponent<AudioSource>();
        character_Controller = GetComponentInParent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootstepSound();
    }
    void CheckToPlayFootstepSound()
    {
        if (!character_Controller.isGrounded)

            return;

        if (character_Controller.velocity.sqrMagnitude > 0)
        {
            acummulate_distance += Time.deltaTime;
            if (acummulate_distance > step_Distance)
            {
                footstep_Sound.volume = Random.Range(Volume_min, Volume_max);
                footstep_Sound.clip = footstep_Clip[Random.Range(0, footstep_Clip.Length)];
                footstep_Sound.Play();
                acummulate_distance = 0f;


            }


        }
        else
        {
            acummulate_distance = 0f;
        }
    }
}
