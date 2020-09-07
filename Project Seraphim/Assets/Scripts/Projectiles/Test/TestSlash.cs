using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSlash : Projectile
{
    public bool reflectProjectiles;
    public bool destroyProjectiles;




    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Entity entityHit = collision.gameObject.GetComponent<Entity>();
            entityHit.Damage(Damage, ElementalEffect, armorPen);
        }
        if (reflectProjectiles)
        {
            //Set up reflection code here
        }

        if ((destroyProjectiles) && (collision.transform.tag == "enemyprojectile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
