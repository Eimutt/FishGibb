using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private int CurrentHealth;
    private int MaxHealth;
    private int Speed;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHealth()
    {
        MaxHealth++;
        CurrentHealth = MaxHealth;
    }

    public void IncreaseSpeed()
    {
        Speed++;
    }

    public float GetSpeed()
    {
        return Speed;
    }
}
