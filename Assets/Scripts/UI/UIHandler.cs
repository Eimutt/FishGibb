using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private GameObject levelBar;
    private GameObject hpBar;
    private GameObject levelText;
    public GameObject skillPointsText;
    public GameObject skillPointsButton;
    public GameObject skillMenu;
    // Start is called before the first frame update
    void Awake()
    {
        levelText = gameObject.transform.Find("LevelText").gameObject;
        levelBar = gameObject.transform.Find("ExpBar").gameObject;
        hpBar = gameObject.transform.Find("HpBar").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateExpBar(int currentExp, int neededExp)
    {
        levelBar.GetComponent<ProgressBar>().SetProgress(currentExp, neededExp);
    }

    public void UpdateHealthBar(int currentHp, int maxHp)
    {
        hpBar.GetComponent<ProgressBar>().SetProgress(currentHp, maxHp);
    }

    public void UpdateLevel(int level)
    {
        levelText.GetComponent<Text>().text = level.ToString();
    }

    public void UpdateTalentPoints(int skillPoints)
    {
        skillPointsText.GetComponent<Text>().text = skillPoints.ToString();
        if (skillPoints > 0)
            skillPointsButton.GetComponent<Button>().interactable = true;
        else
            skillPointsButton.GetComponent<Button>().interactable = false;
    }

    public void OpenSkillMenu()
    {
        Time.timeScale = 0;
        skillMenu.SetActive(true);
    }

    public void CloseSkillMenu()
    {
        Time.timeScale = 1;
        skillMenu.SetActive(false);
    }
}
