using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private int currentLevel;
    private int currentExp;
    private int neededExp;
    //public GameObject LevelDisplay;
    //private LevelDisplay LevelDisplayObj;
    private int TalentPoints;
    private Fish Fish;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        currentExp = 0;
        neededExp = 10;
        //LevelDisplayObj = LevelDisplay.GetComponent<LevelDisplay>();
        Fish = this.GetComponent<Fish>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.gameObject.tag == "Food")
    //    {
    //        Destroy(other.gameObject);
    //        GainExp(1);
    //    }
    //}

    private void LevelUp()
    {

        currentExp = neededExp - currentExp;
        currentLevel++;
        TalentPoints++;
        neededExp += 2;
        //LevelDisplayObj.UpdateLevel(currentLevel);
        //LevelDisplayObj.UpdateTalentPoints(TalentPoints);
    }

    public void GainExp(int exp)
    {
        currentExp += exp;
        if (currentExp >= neededExp)
        {
            LevelUp();
        }
        //LevelDisplayObj.UpdateBar(currentExp, neededExp);
    }

    public void SpendSkillPoint(int id)
    {
        //Add handling of skillpoints
        
        Fish.IncreaseSpeed();
        TalentPoints--;
        //LevelDisplayObj.UpdateTalentPoints(TalentPoints);
    }
}
