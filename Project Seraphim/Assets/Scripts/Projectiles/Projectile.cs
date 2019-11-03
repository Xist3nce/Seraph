using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public GameObject Owner;
    public float Damage;
    public float Speed;
    public enum Element { physical, fire, water, air, earth, lightning, ice, death, life };
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
    public GameObject ParticleEffect;
    private Collider2D col;
    private Rigidbody2D rb;
    private SpriteRenderer sr;


    private void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Shot();
    }
    public virtual void Shot()
    {
        if (TimeTilDeath > 0)
        {
            DeathTimer();
        }
        if (Speed > 0)
        {
            Move();
        }
    }

    public virtual void Move()
    {
        rb.velocity = new Vector2 (0,Speed);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("DamageEntity", Damage);

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
