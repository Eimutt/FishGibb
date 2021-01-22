using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected int currentHp;
    public int maxHp;
    public int speed;

    protected EventManager eventManager;

    private PushPhysics pushPhysics;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        //TryGetComponent(out PushPhysics pushPhysics);
        pushPhysics = GetComponent<PushPhysics>();
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Eat()
    {

    }

    public virtual void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
            Die();
    }
    
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public void Knockback(float force, Vector3 direction)
    {
        if(pushPhysics)
            pushPhysics.AddForce(direction, force);
    }
}
