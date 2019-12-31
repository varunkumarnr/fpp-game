using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintCrouch : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float Sprint_speed = 10f;
    public float Crouch_speed = 2f;
    public float move_speed = 5f;
    private Transform look_Root;
    private float Stand_Height = 1.6f;
    private float Crouch_Height = 1f;
    private bool is_Crouching;
    private PlayerFootsteps player_Footsteps;
    private float sprint_Volume = 1f;
    private float crouch_Volume = 0.1f;
    private float walk_Volume_min = 0.2f, walk_Volume_max = 0.6f;
    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.25f;
    private float crouch_Step_Distance = 0.5f;
    private PlayerStats player_Stats ;
    private float sprint_Value = 100f;
    public float sprint_Troshold = 10f;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        look_Root = transform.GetChild(0);
        player_Footsteps = GetComponentInChildren<PlayerFootsteps>();
        player_Stats = GetComponent<PlayerStats>();
    }
    void Start()
    {
        player_Footsteps.Volume_min = walk_Volume_min;
        player_Footsteps.Volume_max = walk_Volume_max;
        player_Footsteps.step_Distance = walk_Step_Distance;
    }

    void Update()
    {
        Sprint();
        Crouch();
    }
    void Sprint()
    {
        if(sprint_Value>0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching  )
            {
                playerMovement.Speed = Sprint_speed;
                player_Footsteps.step_Distance = sprint_Step_Distance;
                player_Footsteps.Volume_min = sprint_Volume;
                player_Footsteps.Volume_max = sprint_Volume;

            }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
        {
            playerMovement.Speed = Sprint_speed;
            player_Footsteps.step_Distance = sprint_Step_Distance;
            player_Footsteps.Volume_min = sprint_Volume;
            player_Footsteps.Volume_max = sprint_Volume;

        }
       if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        //else
        {
            playerMovement.Speed = move_speed;
            player_Footsteps.step_Distance = walk_Step_Distance;
            player_Footsteps.Volume_min = walk_Volume_min;
            player_Footsteps.Volume_max = walk_Volume_max;
            
        }
        if (Input.GetKey(KeyCode.LeftShift) && !is_Crouching)
        {
            sprint_Value -= sprint_Troshold * Time.deltaTime;
            if (sprint_Value <= 0f)
            {
                sprint_Value = 0f;
                playerMovement.Speed = move_speed;
                player_Footsteps.step_Distance = walk_Step_Distance;
                player_Footsteps.Volume_min = walk_Volume_min;
                player_Footsteps.Volume_max = walk_Volume_max;

            }
            player_Stats.Display_StaminaStats(sprint_Value);
        }
        else
        {


            if (sprint_Value != 100f)
            {
                sprint_Value += (sprint_Troshold / 2f) * Time.deltaTime;
                player_Stats.Display_StaminaStats(sprint_Value);
                if (sprint_Value >= 100f)
                {
                    sprint_Value = 100f;
                }
            }


        }
            
        


    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (is_Crouching == true)
            {
                look_Root.localPosition = new Vector3(0f, Stand_Height, 0f);
                playerMovement.Speed = move_speed;
                is_Crouching = false;
                
            }
            else
            {
                look_Root.localPosition = new Vector3(0f, Crouch_Height, 0f);
               
                playerMovement.Speed = Crouch_speed;
                player_Footsteps.step_Distance = crouch_Step_Distance;
                player_Footsteps.Volume_min = crouch_Volume;
                player_Footsteps.Volume_max = crouch_Volume;

                is_Crouching = true;

            }
        }
    }
        

}   

