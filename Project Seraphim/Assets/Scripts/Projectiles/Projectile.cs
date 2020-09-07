using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : SeraphLibrary
{
    public GameObject Owner;
    public float Damage;
    public float Speed;
    public float Knockback;
    public float armorPen;
    public Element ElementalEffect;
    [Space]
    public float ExplosionDamage;
    public float ExplosionRadius;
    public float Distance;
    public float TimeTilDeath;
    [Space]
    public float ChainCount;
    public float ChainDist;
    [Space]
    public int pierceCount;
    [Space]
    public GameObject ParticleEffect;
    private Collider2D col;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;


    private void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Shot();
    }
    public virtual void Shot()
    {
        if (Speed > 0)
        {
            Move();
        }
        if (TimeTilDeath > 0)
        {
            StartCoroutine(DeathTimer());
        }
    }

    public virtual void Move()
    {
        Debug.Log("Shot TOLD TO MOVE DAMMIT");
        rb.velocity = transform.up * Speed;
    }

    public virtual void Explode()
    {
        //Todo: explosion code
        Debug.Log("Boom");
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Entity entityHit = collision.gameObject.GetComponent<Entity>();
            entityHit.Damage(Damage, ElementalEffect, armorPen);
        }
        Die();

    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(TimeTilDeath);
        if (ExplosionRadius > 0)
        {
            Explode();
        }
        Die();
    }

}
