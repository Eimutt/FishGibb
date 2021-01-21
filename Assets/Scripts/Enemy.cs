using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public enum EnemyType { Hostile, Passive}
    public EnemyType type;
    public int maxHp;
    public float currentHp;
    public int CollisionDamage;
    public float Speed;
    private bool InCombat;
    private GameObject player;
    public float AggroRadius;
    public float KnockbackStrength;
    private GameObject target;
    private Vector3 RandomDirection;
    private bool Patrolling;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
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
                transform.position += RandomDirection * Speed * Time.deltaTime;
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
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction = Vector3.Normalize(target.transform.position - transform.position);
        transform.position += direction * Speed * Time.deltaTime;

        float z = Vector3.SignedAngle(Vector3.up, direction , Vector3.forward);
        Quaternion rotation = Quaternion.Euler(0, 0, z);

        transform.rotation = rotation;
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
        return (Vector3.Distance(gameObject.transform.position, player.transform.position) < AggroRadius);
    }

    public void GetRandomDirection()
    {
        RandomDirection = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector3.right;
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

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
            Destroy(gameObject);
    }

    public void Eat()
    {
        currentHp = currentHp < maxHp ? currentHp+1 : currentHp;
        transform.localScale = transform.localScale.x < 10.0f ? transform.localScale * 1.1f : transform.localScale; 
    }
}
