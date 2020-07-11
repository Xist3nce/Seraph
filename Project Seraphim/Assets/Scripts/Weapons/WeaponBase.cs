using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : SeraphLibrary
{

    public float Damage = 1;
    public float ProjectileSpeed = 1;
    public float ReloadTime = 1;
    public float FireRate = 1;
    public int ClipSize = 3;
    public int shotsLeft;
    public int pierceCount;
    public float armorPen;
    public Element passedElement;
    [Space]
    public float DamageMod = 0;
    public float ProjectileSpeedMod = 0;
    public float ReloadTimeMod = 1;
    public float FireRateMod = 0;
    public float ClipSizeMod = 0;
    [Space]
    public PlayerStatus PlayerStatus;
    public MouseAimer Aimer;
    public GameObject ProjectileGO;
    public Animator AnimController;
    public GameObject GroundItem;
    [Space]
    public bool Initialized;

    public Vector3 shotOffset;


    public void Awake()
    {
        if (Aimer == null)
        {
            Aimer = GetComponentInParent<MouseAimer>();
        }
        if (AnimController == null)
        {
            AnimController = GetComponent<Animator>();
        }
    }

    public virtual void OnEnable()
    {
        if (!Initialized)
        {
            Initialize();
        }
    }

    public virtual void Initialize()
    {

    }

    public virtual void FireWeapon()
    {
        Projectile createdProjectile = Instantiate(ProjectileGO, transform.position + shotOffset, Aimer.gameObject.transform.rotation).GetComponent<Projectile>();
        createdProjectile.Damage = (Damage * DamageMod);
        createdProjectile.Speed = (ProjectileSpeed * ProjectileSpeedMod);
        createdProjectile.ExplosionDamage = (Damage * DamageMod) * .2f;
        createdProjectile.pierceCount = pierceCount;
        if (passedElement != Element.none)
        {
            createdProjectile.ElementalEffect = passedElement;
            Debug.Log(createdProjectile.name + "Element shifted to " + passedElement);
        }

    }

}
