using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
    
{ 
    [SerializeField]
    WeaponHandeler[] weapons;
    private int current_Weapon_Index;
    // Start is called before the first frame update
    void Start()

    {
        current_Weapon_Index = 0;
        weapons[current_Weapon_Index].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            TurnOnSelectionWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            TurnOnSelectionWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            TurnOnSelectionWeapon(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            TurnOnSelectionWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
        {
            TurnOnSelectionWeapon(4);
        }
       if (Input.GetKeyDown(KeyCode.Alpha6)) 
        {
            TurnOnSelectionWeapon(5);
        }


    }
    void TurnOnSelectionWeapon(int weapon_Index)
    {
        if (current_Weapon_Index == weapon_Index)
            return;
        weapons[current_Weapon_Index].gameObject.SetActive(false);
        weapons[weapon_Index].gameObject.SetActive(true);
        current_Weapon_Index = weapon_Index;
    }
    public WeaponHandeler GetCurrentSelectedWeapon()
    {
        return weapons[current_Weapon_Index];
    }
}
