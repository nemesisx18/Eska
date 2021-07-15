using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class WeaponSwitching : NetworkBehaviour
{
    [SerializeField]
    private Transform weaponSlot;
    
    public int selectedWeapon = 0;
    
    void Start()
    {
        DrawWeapon();
    }

    void FixedUpdate()
    {
        int previousSelectedWeapon = selectedWeapon;
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= weaponSlot.transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = weaponSlot.transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            DrawWeapon();
        }
    }

    [Client]
    void DrawWeapon()
    {
        CmdWeapon();
    }

    [Command]
    void CmdWeapon()
    {
        RpcSelectWeapon();
    }

    [ClientRpc]
    void RpcSelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in weaponSlot.transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
