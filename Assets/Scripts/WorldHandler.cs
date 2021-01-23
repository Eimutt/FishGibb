using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHandler : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int neededExp;
    private EventManager eventManager;
    private Unlocks unlocks;
    private EnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        currentExp = 0;
        neededExp = 10;
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        unlocks = GetComponent<Unlocks>();
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
        unlocks.EarnSkillPoint();

        if (currentLevel == 10)
            AdvanceStage();
    }

    private void CalculateNextExpReq()
    {
        neededExp += 2;
    }

    private void AdvanceStage()
    {
        enemySpawner.AdvanceStage();
    }

}
