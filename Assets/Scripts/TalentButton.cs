using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentButton : MonoBehaviour
{
    public int cost;
    public Unlocks unlocks;
    // Start is called before the first frame update
    void Start()
    {
        EventManager eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        eventManager.UpdateFreeTalents.AddListener((int amount) => UpdateButton(amount));
        unlocks = GameObject.Find("WorldHandler").GetComponent<Unlocks>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateButton(int amount)
    {
        if(cost > amount)
        {
            GetComponentInChildren<Button>().interactable = false;
        }
    }
}
