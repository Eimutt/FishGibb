using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Unit
{
    public enum EnemyType { Hostile, Passive}
    public EnemyType type;
    //public int maxHp;
    //public float currentHp;
    //public float Speed;
    public int CollisionDamage;
    
    protected bool InCombat;
    private GameObject player;
    public float LeashRange;
    public float KnockbackStrength;
    private GameObject target;
    private Vector3 RandomDirection;
    private bool Patrolling;
    private float timer;
    public int experience;
    private float currentGrowth;
    public float maxGrowth;
    private int incomingDamage;
    public float despawnRange;
    private float baseSize;
    private bool dead;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
        currentHp = maxHp;
        currentGrowth = transform.Find("Sprite").localScale.x;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (InCombat)
        {
            if (!IsInRangeOfPlayer())
            {
                InCombat = false;
                target = null;
            } else
            {
                MoveTowardsTarget();
            }
        } else if (target)
        {
            MoveTowardsTarget();
        } else
        {
            if (Patrolling)
            {
                transform.position += RandomDirection * speed * Time.deltaTime;
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    Patrolling = false;
                    timer = 0;
                }
            } else
            {
                GetRandomDirection();
            }
        }
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > despawnRange)
            Destroy(this.gameObject);
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction = Vector3.Normalize(target.transform.position - transform.position);
        transform.position += direction * speed * Time.deltaTime;

        float z = Vector3.SignedAngle(Vector3.up, direction , Vector3.forward);
        Quaternion rotation = Quaternion.Euler(0, 0, z);

        transform.GetChild(0).transform.rotation = rotation;
    }

    public int GetDamage()
    {
        return CollisionDamage;
    }

    public float GetKnockbackStrength()
    {
        return KnockbackStrength;
    }

    public bool IsInRangeOfPlayer()
    {
        return (Vector3.Distance(gameObject.transform.position, player.transform.position) < LeashRange * transform.localScale.x);
    }

    public void GetRandomDirection()
    {
        RandomDirection = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector3.right;
        float z = Vector3.SignedAngle(Vector3.up, RandomDirection, Vector3.forward);
        Quaternion rotation = Quaternion.Euler(0, 0, z);

        transform.Find("Sprite").transform.rotation = rotation;
        Patrolling = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InCombat = true;
            target = collision.gameObject;
            Patrolling = false;
        } else if (collision.gameObject.tag == "Food")
        {
            if (!target)
            {
                target = collision.gameObject;
            }

            Patrolling = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            if (!target)
            {
                target = collision.gameObject;
            }

            Patrolling = false;
        }
    }

    public override void Eat()
    {
        //Should monsters regenerate hp?
        //currentHp = currentHp < maxHp ? currentHp+1 : currentHp;

        if(currentHp < maxHp)
        {
            currentHp += 1;
            eventManager.DamageEvent(this.gameObject, -1, GetHpPercentage());
        }
        if(currentGrowth <= maxGrowth)
        {
            currentGrowth *= 1.1f;
            transform.Find("Sprite").transform.localScale = new Vector3(currentGrowth, currentGrowth, currentGrowth);
        }
    }

    public override void Die()
    {
        if (!dead)
        {
            dead = true;
            GetComponent<Drops>().DropStuff();
            eventManager.GainExpEvent(this.experience);
            Destroy(gameObject);
        }
    }


    public override void TakeDamage(int damage)
    {
        currentHp -= damage;
        incomingDamage -= damage;
        eventManager.DamageEvent(this.gameObject, damage, GetHpPercentage());
        if (currentHp <= 0)
            Die();
    }
    public void IncreaseIncomingDamage(int damage)
    {
        incomingDamage += damage;
    }

    public bool WillSurvive()
    {
        return (incomingDamage < currentHp);
    }
}
