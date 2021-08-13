using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHandler : MonoBehaviour
{
    private EventManager eventManager;
    private Unlocks unlocks;
    private EnemySpawner enemySpawner;

    private int level;
    private int worldStage;

    // Start is called before the first frame update
    void Start()
    {
        worldStage = 1;
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        unlocks = GetComponent<Unlocks>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp(int newLevel)
    {
        if (newLevel % 3 == 0)
            AdvanceStage();
    }

    private void AdvanceStage()
    {
        enemySpawner.AdvanceStage();
    }

}
