using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIHandler : MonoBehaviour
{
    public GameObject defaultText;
    public bool showDamageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(GameObject target, int damage, float percentHp)
    {
        if (showDamageText)
        {
            CreateDamageText(target, damage);
        }

        target.transform.Find("Canvas/Slider").GetComponent<Slider>().value = percentHp;
    }


    public void CreateDamageText(GameObject target, int damage)
    {
        GameObject text = Instantiate(defaultText);
        Text myText = text.GetComponent<Text>();
        text.transform.position = target.transform.position;
        if(damage > 0)
        {
            myText.text = "-" + damage.ToString();
        } 
        else
        {
            myText.text = "+" + (damage *= -1).ToString();
            myText.color = Color.green;
        }
    }
}
