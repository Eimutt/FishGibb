using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTuple
{
    public UnlockTuple(int cost, int skillPoints)
    {
        this.cost = cost;
        this.skillPoints = skillPoints;
    }
    public int cost;
    public int skillPoints;
}

public class Unlocks : MonoBehaviour
{
    private StatUnlock[] StatsUnlocks;
    public int skillPoints;
    private EventManager eventManager;
    public GameObject fish;
    public GameObject[] weaponPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        StatsUnlocks = new StatUnlock[3];
        StatsUnlocks[0] = new StatUnlock(0, "Health", 1, 10);
        StatsUnlocks[1] = new StatUnlock(1, "Speed", 1, 10);
        StatsUnlocks[2] = new StatUnlock(2, "Damage", 2, 10);
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EarnSkillPoint()
    {
        skillPoints++;
    }

    public void IncreaseStat(int Id)
    {
        StatUnlock statUnlock = StatsUnlocks[Id];
        skillPoints -= statUnlock.GetCost();

        switch (Id)
        {
            case 0:
                fish.GetComponent<Fish>().IncreaseHealth();
                break;
            case 1:
                fish.GetComponent<Fish>().IncreaseSpeed();
                break;
        }


        statUnlock.IncreaseStat();
        int newCost = statUnlock.GetCost();

        eventManager.UpdateFreeTalentsEvent(skillPoints);
        eventManager.UpdateUnlockEvent(Id, newCost, skillPoints);
    }

    public void UnlockWeapon(int weaponId)
    {
        Instantiate(weaponPrefabs[weaponId], fish.transform);
        eventManager.UpdateFreeTalentsEvent(skillPoints);
    }

    public int GetSkillPoints()
    {
        return skillPoints;
    }

    public int GetCost(int skillId)
    {
        return StatsUnlocks[skillId].GetCost();
    }

    public UnlockTuple GetUnlockStatus(int skillId)
    {
        return new UnlockTuple(GetCost(skillId), skillPoints);
    }
}
