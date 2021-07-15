using UnityEngine;
using System.Collections;
using Mirror;

public class WeaponManager : NetworkBehaviour
{
    [SerializeField]
    private string weaponLayerName = "Weapon";

    [SerializeField]
    private Transform tecweaponHolder;

    [SerializeField]
    private Transform awpweaponHolder;

    [SerializeField]
    private PlayerWeapon primaryWeapon;

    [SerializeField]
    private PlayerWeapon secondWeapon;

    private PlayerWeapon currentWeapon;
    private WeaponGraphics currentGraphics;

    private Transform currentHolder;

    public bool isReloading = false;

    void Start()
    {
        currentHolder = awpweaponHolder;
        EquipWeapon(primaryWeapon);
    }

    void Update()
    {
        if(Input.GetAxis("WeaponSwitch") >0f)
        {
            currentHolder = tecweaponHolder;
            EquipWeapon(secondWeapon);
            Debug.Log("switched weapon");
        }
        else if (Input.GetAxis("WeaponSwitch") < 0f)
        {
            currentHolder = awpweaponHolder;
            EquipWeapon(primaryWeapon);
            Debug.Log("switched weapon back");
        }
    }

    public PlayerWeapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public WeaponGraphics GetCurrentGraphics()
    {
        return currentGraphics;
    }

    void EquipWeapon (PlayerWeapon _weapon)
    {
        foreach (Transform child in tecweaponHolder)
        {
            Destroy(child.gameObject);
        }

        currentWeapon = _weapon;

        GameObject _weaponIns = Instantiate(_weapon.graphics, tecweaponHolder.position, tecweaponHolder.rotation);
        _weaponIns.transform.SetParent(tecweaponHolder);

        currentGraphics = _weaponIns.GetComponent<WeaponGraphics>();
        if (currentGraphics == null)
            Debug.LogError("No WeaponGraphics component on the weapon object: " + _weaponIns.name);

        if (isLocalPlayer)
        {
            Util.SetLayerRecursively(_weaponIns, LayerMask.NameToLayer(weaponLayerName));
        }
    }

    public void Reload()
    {
        if (isReloading)
            return;
        StartCoroutine(Reload_Coroutine());
    }

    private IEnumerator Reload_Coroutine ()
    {
        Debug.Log("Reloading..");

        isReloading = true;

        currentWeapon.magBullets = currentWeapon.magBullets - currentWeapon.timePlayerShoot;
        
        yield return new WaitForSeconds(currentWeapon.reloadTime);

        currentWeapon.timePlayerShoot = 0;

        currentWeapon.bullets = currentWeapon.maxBullets;
        
        isReloading = false;
    }
}
