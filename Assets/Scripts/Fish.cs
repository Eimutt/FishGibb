using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    private Unlocks Unlocks;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        eventManager.UpdateLifeEvent(currentHp, maxHp);
        Unlocks = this.GetComponent<Unlocks>();
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
        eventManager.UpdateLifeEvent(currentHp, maxHp);
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

                
            }

        }
    }

    public override void Eat()
    {
        eventManager.GainExpEvent(1);
    }

    public override void TakeDamage(int damage)
    {
        if (!Invulnerable)
        {
            Invulnerable = true;
            InvulnerabilityColor.SetTintColor(DamagedColor, InvulnerabilityDuration);
            currentHp -= damage;
            eventManager.UpdateLifeEvent(currentHp, maxHp);

            if(currentHp <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
