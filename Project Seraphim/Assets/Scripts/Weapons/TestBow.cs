using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBow : WeaponBase
{
    [SerializeField]
    private bool triggerHeld;
    [SerializeField]
    private float holdTimer;

    [Space]
    [SerializeField]
    private float maxChargeTime = .7f;
    [SerializeField]
    private float minChargeTime = .3f;
    [SerializeField]
    private float maxChargeMod = 1f;
    [SerializeField]
    private float minChargeMod = 0.5f;
    [SerializeField]
    private int shotCharge = 0;
    private float chargeMod;

    [SerializeField]
    private float TimePassed;




    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            holdTimer = Time.time;
            triggerHeld = true;

        }
        if (Input.GetButton("Fire1"))
        {
            AnimController.SetInteger("ShotType", shotCharge);
            if ((Time.time - holdTimer < minChargeTime) && (Time.time - holdTimer < holdTimer))
            {
                shotCharge = 1;

            }
            if ((Time.time - holdTimer > minChargeTime) && (Time.time - holdTimer < maxChargeTime))
            {
                shotCharge = 2;

            }
            if (Time.time - holdTimer > maxChargeTime) 
            {
                shotCharge = 3;

            }
            triggerHeld = true;
            TimePassed = Time.time - holdTimer;
        }
        if (!(Input.GetButton("Fire1")))
        {
            triggerHeld = false;

        }
        if (Input.GetButtonUp("Fire1"))
        {
            Release();
        }
    }
    private void Release()
    {
        if (shotCharge == 1)
        {
            Debug.Log("Misfire, didn't charge long enough");
        }
        if (shotCharge == 2)
        {
            Debug.Log("Low speed shot");
            chargeMod = minChargeMod;
            FireWeapon();
        }
        if (shotCharge == 3)
        {
            Debug.Log("Full Speed shot");
            chargeMod = maxChargeMod;
            FireWeapon();

        }
        shotCharge = 0;
        AnimController.SetInteger("ShotType", shotCharge);
        triggerHeld = false;
    }

    public override void FireWeapon()
    {
        Projectile createdProjectile = Instantiate(ProjectileGO, transform.position + shotOffset, Aimer.gameObject.transform.rotation).GetComponent<Projectile>();
        createdProjectile.Damage = (Damage * DamageMod) * chargeMod;
        createdProjectile.Speed = (ProjectileSpeed * ProjectileSpeedMod) * chargeMod;
        createdProjectile.ExplosionDamage = (Damage * DamageMod) * .2f;
        createdProjectile.pierceCount = pierceCount;
        if (passedElement != Element.none)
        {
            createdProjectile.ElementalEffect = passedElement;
            Debug.Log(createdProjectile.name + "Element shifted to " + passedElement);
        }


    }


}
