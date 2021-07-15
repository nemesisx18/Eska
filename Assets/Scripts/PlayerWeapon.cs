using UnityEngine;

[System.Serializable]
public class PlayerWeapon
{
    public string name = "Weap1";

    public int damage = 10;
    public float range = 100f;

    public float fireRate = 0f;

    public int maxBullets = 20;
    [HideInInspector]
    public int bullets;
    [HideInInspector]
    public int timePlayerShoot;

    public int magBullets;

    public float reloadTime = 1f;
    
    public GameObject graphics;

    public PlayerWeapon ()
    {
        bullets = maxBullets;
    }
}
