using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSword : WeaponBase
{
    private int _swingCounter;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1") && canFire))
        {
            Swing();
        }

    }

    void Swing()
    {
        if (!(PlayerMovement.instance.stunned) && (shotsLeft != 0))//If shots left is not 0,
        {
            FireWeapon();
            StartCoroutine(TimeBetweenShots());
        }

        if (!(PlayerMovement.instance.stunned) && (shotsLeft == 0) && !canFire) //If shots left equals 0, reload.
        {
            StartCoroutine(Reload());
        }
    }


    public override void FireWeapon()
    {
        base.FireWeapon();
        shotsLeft --;
        if (shotsLeft == 0)
        {
            canFire = false;
        }
    }
}
