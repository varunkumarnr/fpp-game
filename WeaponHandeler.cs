using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponAim
{
   NONE,
   SELF_AIM,
   AIM
}

public enum WeaponFireType
{
    SINGLE,
    MULTIPLE
}
public enum WeaponBulletType
{
    BULLET,
    SPEAR,
    ARROW,
    NONE
}
public class WeaponHandeler : MonoBehaviour
{
    private Animator anim;
    public WeaponAim Weapon_Aim;
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private AudioSource ShootSound, Reload_Sound;
    public WeaponFireType fireType;
    public WeaponBulletType bulletType;
    public GameObject Attack_Point;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void ShootAnimation()
    {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }
    
    public void Aim(bool CanAim)
    {
        anim.SetBool(AnimationTags.AIM_PARAMETER, CanAim);
    }
    void Turn_On_muzzleFlash()
    {
        muzzleFlash.SetActive(true);
    }
    void Turn_Off_muzzleFlash()
    {
        muzzleFlash.SetActive(false);

    }
    void Play_ShootSound()
    {
        ShootSound.Play();

    }
    void Play_ReloadSound()
    {
        Reload_Sound.Play();
    }
    void Turn_On_AttackPoint()
    {
        Attack_Point.SetActive(true);
    }
    void Turn_Off_AttackPoint()
    {
        if (Attack_Point.activeInHierarchy)
        {
            Attack_Point.SetActive(false);
        }
    }
}
