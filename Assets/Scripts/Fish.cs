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
    private EventManager EventManager;
    // Start is called before the first frame update
    void Start()
    {
        EventManager = EventManagerObj.GetComponent<EventManager>();
        Speed = 2;
        CurrentHealth = 10;
        MaxHealth = 10;
        EventManager.UpdateMaxLifeEvent(MaxHealth);
        EventManager.UpdateLifeEvent(CurrentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TakeDamage(1);
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
}
