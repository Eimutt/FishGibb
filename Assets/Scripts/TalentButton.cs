using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentButton : MonoBehaviour
{
    public int id;
    public int cost;
    public Unlocks unlocks;
    private EventManager eventManager;
    private bool init = false;
    private Text costText;
    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        eventManager.UpdateUnlock.AddListener((int id, int newCost, int skillPoints) => UpdateStatus(id, newCost, skillPoints));
        unlocks = GameObject.Find("Fish").GetComponent<Unlocks>();
        costText = transform.Find("Cost").GetComponent<Text>();
        init = true;
        GetStatus();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateButton(int amount)
    {
        if (cost > amount)
        {
            GetComponentInChildren<Button>().interactable = false;
        }
        else
        {
            GetComponentInChildren<Button>().interactable = true;
        }
    }

    private void OnEnable()
    {
        if (init)
        {
            GetStatus();
        }
    }

    private void UpdateStatus(int id, int newCost, int skillPoints)
    {
        if (id == this.id)
        {
            this.cost = newCost;
            costText.text = "Cost: " + cost.ToString();
        }
        UpdateButton(skillPoints);
    }

    private void GetStatus()
    {
        UnlockTuple unlockStatus = unlocks.GetUnlockStatus(id);
        this.cost = unlockStatus.cost;
        costText.text = "Cost: " + cost.ToString();
        UpdateButton(unlockStatus.skillPoints);
    }
}
