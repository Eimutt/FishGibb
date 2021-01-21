using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fish : MonoBehaviour
{
    private int CurrentHealth;
    private int MaxHealth;
    private int Speed;
    public GameObject EventManagerObj;
    public float InvulnerabilityDuration;
    private bool Invulnerable;
    private float InvulnerabilityTimer = 0;
    private EventManager EventManager;
    private bool InCombat;
    private PushPhysics PushPhysics;
    public Color DamagedColor;
    [SerializeField] private InvulnerabilityColor InvulnerabilityColor;
    // Start is called before the first frame update
    void Start()
    {
        EventManager = EventManagerObj.GetComponent<EventManager>();
        Speed = 2;
        CurrentHealth = 10;
        MaxHealth = 10;
        EventManager.UpdateMaxLifeEvent(MaxHealth);
        EventManager.UpdateLifeEvent(CurrentHealth);
        PushPhysics = gameObject.GetComponent<PushPhysics>();
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
        MaxHealth++;
        CurrentHealth = MaxHealth;
        EventManager.UpdateMaxLifeEvent(CurrentHealth);
        EventManager.UpdateLifeEvent(CurrentHealth);
    }

    public void IncreaseSpeed()
    {
        Speed++;
    }

    public float GetSpeed()
    {
        return Speed;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        EventManager.UpdateLifeEvent(CurrentHealth);
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

    private void Knockback(float force, Vector3 direction)
    {
        PushPhysics.AddForce(direction, force);
    }

}
