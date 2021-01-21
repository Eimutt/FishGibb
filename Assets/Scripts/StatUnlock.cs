using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUnlock
{
    private int id;
    private string name;
    private int currentLvl;
    private int maxLvl;
    private int cost;


    public StatUnlock(int id, string name, int startingCost, int maxLvl)
    {
        this.id = id;
        this.name = name;
        this.cost = startingCost;
        this.currentLvl = 1;
        this.maxLvl = maxLvl;
    }

    public int GetCurrentLvl()
    {
        return currentLvl;
    }

    public int GetMaxLvl()
    {
        return maxLvl;
    }

    public int GetCost()
    {
        return cost;
    }

    public string GetName()
    {
        return name;
    }


    public void IncreaseStat()
    {
        currentLvl++;
        cost = CalculateNewCost(cost);
    }

    //Maybe make this more complicated
    private int CalculateNewCost(int cost)
    {
        return cost++;
    }

}
