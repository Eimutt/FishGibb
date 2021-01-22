﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fish : Unit
{
    //private int CurrentHealth;
    //private int MaxHealth;
    //private int Speed;
    public float InvulnerabilityDuration;
    private bool Invulnerable;
    private float InvulnerabilityTimer = 0;
    private bool InCombat;
    public Color DamagedColor;
    [SerializeField] private InvulnerabilityColor InvulnerabilityColor;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        eventManager.UpdateMaxLifeEvent(maxHp);
        eventManager.UpdateLifeEvent(currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Invulnerable)
        {
            InvulnerabilityTimer += Time.deltaTime;
            if(InvulnerabilityTimer > InvulnerabilityDuration)
            {
                Invulnerable = false;
                InvulnerabilityTimer = 0;
            }
        }
    }

    public void IncreaseHealth()
    {
        maxHp++;
        currentHp = maxHp;
        eventManager.UpdateMaxLifeEvent(currentHp);
        eventManager.UpdateLifeEvent(currentHp);
    }

    public void IncreaseSpeed()
    {
        speed++;
    }

    public float GetSpeed()
    {
        return speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!Invulnerable)
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                TakeDamage(enemy.GetDamage());

                Vector3 direction = Vector3.Normalize(transform.position - other.transform.position);
                Knockback(enemy.GetKnockbackStrength(), direction);

                Invulnerable = true;
                InvulnerabilityColor.SetTintColor(DamagedColor, InvulnerabilityDuration);
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!Invulnerable)
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                TakeDamage(enemy.GetDamage());

                Vector3 direction = Vector3.Normalize(transform.position - other.transform.position);
                Knockback(enemy.GetKnockbackStrength(), direction);

                Invulnerable = true;
                InvulnerabilityColor.SetTintColor(DamagedColor, InvulnerabilityDuration);
            }

        }
    }

    public override void Eat()
    {
        eventManager.GrantExperienceEvent(1);
    }

    public override void TakeDamage(int damage)
    {
        currentHp -= damage;
        eventManager.UpdateLifeEvent(currentHp);
    }
}
