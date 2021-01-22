using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{

}

[System.Serializable]
public class MyIntTupleEvent: UnityEvent<int, int>
{

}

public class EventManager : MonoBehaviour
{
    public MyIntEvent UpdateMaxLife;
    public MyIntTupleEvent UpdateCurrentExperience;
    public MyIntTupleEvent UpdateCurrentLife;
    public MyIntEvent LevelUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLifeEvent(int current, int max)
    {
        UpdateCurrentLife.Invoke(current, max);
    }

    public void UpdateMaxLifeEvent(int max)
    {
        UpdateMaxLife.Invoke(max);
    }

    public void GrantExperienceEvent(int current, int max)
    {
        UpdateCurrentExperience.Invoke(current, max);
    }

    public void LevelUpEvent(int level)
    {
        LevelUp.Invoke(level);
    }
}
