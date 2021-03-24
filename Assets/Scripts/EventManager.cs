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

[System.Serializable]
public class MyGobjEvent: UnityEvent<GameObject, int, float>
{

}

public class EventManager : MonoBehaviour
{
    public MyIntEvent UpdateMaxLife;
    public MyIntTupleEvent UpdateCurrentExperience;
    public MyIntTupleEvent UpdateCurrentLife;
    public MyIntEvent LevelUp;
    public MyGobjEvent DoDamage;
    public MyIntEvent GainExp;
    public MyIntTupleEvent PickupItem;
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

    public void GainExpEvent(int exp)
    {
        GainExp.Invoke(exp);
    }

    public void LevelUpEvent(int level)
    {
        LevelUp.Invoke(level);
    }

    public void DamageEvent(GameObject gameObject, int dmg, float percentHp)
    {
        DoDamage.Invoke(gameObject, dmg, percentHp);
    }

    public void PickUpItemEvent(int itemId, int quantity)
    {
        PickupItem.Invoke(itemId, quantity);
    }
}
