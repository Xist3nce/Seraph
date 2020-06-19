using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : SeraphLibrary
{
    [SerializeField]
    private bool isActive;
    [Space]
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float health;
    private float armorValue;
    public Element aspect;
    public Element weakAspect;
    private Animator animController;



    private void Start()
    {
        health = maxHealth;
    }
    void OnEnable()
    {
        
    }

    public virtual void Heal(float amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }


    public virtual void Damage(float amount, Element elementalDamage, float armorPen)
    {
        float preCompDamage = 0;
        if ((aspect == elementalDamage) && (elementalDamage != Element.none))
        {
            preCompDamage = (amount / 2f);
            float finalDMG = (preCompDamage - (armorValue - armorPen));
            health -=finalDMG;
            HealthCheck();
            Debug.Log("Same aspect, PreComp: " + preCompDamage + " Final Damage: " + finalDMG);
        }
        if ((weakAspect == elementalDamage) && (elementalDamage != Element.none))
        {
            preCompDamage = (amount*1.5f);
            float finalDMG = (preCompDamage - (armorValue - armorPen));
            health -= finalDMG;
            HealthCheck();
            Debug.Log("Weakness aspect, PreComp: " + preCompDamage + " Final Damage: " + finalDMG);


        }
        if (((aspect != elementalDamage) && (weakAspect != elementalDamage)) || elementalDamage == Element.none)
        {
            preCompDamage = (amount);
            float finalDMG = (preCompDamage - (armorValue - armorPen));
            health -= finalDMG;
            HealthCheck();
            Debug.Log("Normal Damage, PreComp: " + preCompDamage + " Final Damage: " + finalDMG);

        }

    }

    public virtual void PureDamage(float amount)
    {
        health = -amount;
    }

    private void HealthCheck()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(gameObject + "is dead");
        GameObject.Destroy(gameObject);
    }
    public virtual void Kill()
    {
        Damage(9999, Element.death, 9999);
    }

}
