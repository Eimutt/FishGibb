using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    public GameObject LevelBar;
    public GameObject LevelText;
    public GameObject ExperienceText;
    public GameObject SkillPointsText;
    public GameObject SkillPointsButton;
    public GameObject SkillMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBar(int currentExp, int neededExp)
    {
        LevelBar.GetComponent<LevelBar>().SetProgress(currentExp, neededExp);
        ExperienceText.GetComponent<Text>().text = currentExp.ToString() + " / " + neededExp.ToString();
    }

    public void UpdateLevel(int level)
    {
        LevelText.GetComponent<Text>().text = level.ToString();
    }

    public void UpdateTalentPoints(int skillPoints)
    {
        SkillPointsText.GetComponent<Text>().text = skillPoints.ToString();
        if (skillPoints > 0)
            SkillPointsButton.GetComponent<Button>().interactable = true;
        else
            SkillPointsButton.GetComponent<Button>().interactable = false;
    }

    public void OpenSkillMenu()
    {
        Time.timeScale = 0;
        SkillMenu.SetActive(true);
    }

    public void CloseSkillMenu()
    {
        Time.timeScale = 1;
        SkillMenu.SetActive(false);
    }
}
