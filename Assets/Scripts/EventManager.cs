using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{

}

public class EventManager : MonoBehaviour
{
    public MyIntEvent UpdateCurrentLife;
    public MyIntEvent UpdateMaxLife;
    public MyIntEvent GrantExperience;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLifeEvent(int current)
    {
        UpdateCurrentLife.Invoke(current);
    }

    public void UpdateMaxLifeEvent(int max)
    {
        UpdateMaxLife.Invoke(max);
    }

    public void GrantExperienceEvent(int experience)
    {
        GrantExperience.Invoke(experience);
    }
}
