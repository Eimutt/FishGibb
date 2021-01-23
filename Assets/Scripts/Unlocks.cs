using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocks : MonoBehaviour
{
    private StatUnlock[] StatsUnlocks;
    private int skillPoints;
    private EventManager eventManager;
    // Start is called before the first frame update
    void Start()
    {
        StatsUnlocks = new StatUnlock[3];
        StatsUnlocks[0] = new StatUnlock(0, "Health", 1, 10);
        StatsUnlocks[0] = new StatUnlock(1, "Damage", 2, 10);
        StatsUnlocks[0] = new StatUnlock(2, "Speed", 1, 10);
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
}
