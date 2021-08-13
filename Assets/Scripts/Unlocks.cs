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

    public int currentLevel;
    public int currentExp;
    public int neededExp;
    public float expIncreaseModifier;
    public int flatExpIncrease;

    private StatUnlock[] StatsUnlocks;
    public int skillPoints;
    private EventManager eventManager;
    private Fish Fish;
    public GameObject[] weaponPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        currentExp = 0;
        neededExp = 10;

        StatsUnlocks = new StatUnlock[3];
        StatsUnlocks[0] = new StatUnlock(0, "Health", 1, 10);
        StatsUnlocks[1] = new StatUnlock(1, "Speed", 1, 10);
        StatsUnlocks[2] = new StatUnlock(2, "Damage", 2, 10);
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        Fish = this.GetComponent<Fish>();

        eventManager.GrantExperienceEvent(currentExp, neededExp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainExp(int exp)
    {
        currentExp += exp;
        if (currentExp >= neededExp)
        {
            LevelUp();
        }

        //update UI
        eventManager.GrantExperienceEvent(currentExp, neededExp);
    }

    private void LevelUp()
    {
        currentExp = currentExp - neededExp;
        currentLevel++;
        CalculateNextExpReq();
        //give out talentpoints / other level up stuff
        eventManager.LevelUpEvent(currentLevel);
        EarnSkillPoint();

        //if (currentLevel % 3 == 0)
        //    AdvanceStage();
    }

    private void CalculateNextExpReq()
    {
        neededExp = (int)(expIncreaseModifier * (neededExp + flatExpIncrease));
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
                Fish.IncreaseHealth();
                break;
            case 1:
                Fish.IncreaseSpeed();
                break;
        }


        statUnlock.IncreaseStat();
        int newCost = statUnlock.GetCost();

        eventManager.UpdateFreeTalentsEvent(skillPoints);
        eventManager.UpdateUnlockEvent(Id, newCost, skillPoints);
    }

    public void UnlockWeapon(int weaponId)
    {
        Instantiate(weaponPrefabs[weaponId], this.transform);
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
