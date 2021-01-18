using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private int currentLevel;
    private float currentExp;
    private float neededExp;
    public GameObject LevelBar;
    public GameObject LevelText;
    private int TalentPoints;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        currentExp = 0;
        neededExp = 10;
        ChangeDisplayLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        currentExp++;
        if(currentExp == neededExp)
        {
            LevelUp();
        }
        LevelBar.GetComponent<LevelBar>().SetProgress(currentExp, neededExp);
    }

    private void LevelUp()
    {
        currentLevel++;
        TalentPoints++;
        currentExp = 0;
        neededExp += 2;
        ChangeDisplayLevel(currentLevel);
    }

    private void ChangeDisplayLevel(int level)
    {
        LevelText.GetComponent<Text>().text = level.ToString(); 
    }
}
