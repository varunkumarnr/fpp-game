using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;
    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;
    private Animator ZoomCameraAnim;
    private bool zoomed;
    private Camera mainCam;
    private GameObject crosshair;
    private bool is_Aiming;
    [SerializeField]
    private GameObject arrow_prefab, spear_prefab;
    [SerializeField]
    private Transform arrow_spear_StartPosition;
    void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();
        //ZoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);
        mainCam = Camera.main;

    }
    

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
        ZoomInAndOut();
        
    }
    void WeaponShoot()
    {
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                BulletFired();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAGS)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                }
                if (weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                    BulletFired();
                }
                else
                {
                    if(is_Aiming)
                    {
                        weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                        if(weapon_Manager.GetCurrentSelectedWeapon().bulletType==WeaponBulletType.ARROW)
                        {
                            ThrowArrowOrSpear(true);
                        }
                        else if(weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.SPEAR)
                        {
                            ThrowArrowOrSpear(false);
                        }
                    }
                }

            }
        }
        
    }
    void ZoomInAndOut()
    {
        if(weapon_Manager.GetCurrentSelectedWeapon().Weapon_Aim==WeaponAim.AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                ZoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);
                crosshair.SetActive(false);  
            }
            if (Input.GetMouseButtonUp(1))
            {
                ZoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                crosshair.SetActive(true);
            }

        }
        if (weapon_Manager.GetCurrentSelectedWeapon().Weapon_Aim == WeaponAim.SELF_AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                weapon_Manager.GetCurrentSelectedWeapon().Aim(true);
                is_Aiming = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                weapon_Manager.GetCurrentSelectedWeapon().Aim(false);
                is_Aiming = false;
            }
        }
    }
    void ThrowArrowOrSpear(bool throwArrow)
    {
        if (throwArrow)
        {
            GameObject arrow = Instantiate(arrow_prefab);
            arrow.transform.position = arrow_spear_StartPosition.position;
            arrow.GetComponent<ArrowAndBow>().Launch(mainCam);
        }
        else
        {
            GameObject spear = Instantiate(spear_prefab);
            spear.transform.position = arrow_spear_StartPosition.position;
            spear.GetComponent<ArrowAndBow>().Launch(mainCam);
        }
    }
    void BulletFired()
    {
        RaycastHit hit;
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            print("we touched:" +hit.transform.gameObject.name);
            if (hit.transform.tag == Tags.ENEMEY_TAGS)
            {
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage); 
                
            }
  
        }
        
    }
}

