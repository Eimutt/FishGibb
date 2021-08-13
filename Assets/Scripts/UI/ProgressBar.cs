using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float StartPercentage;
    public Color FullColor;
    public Color EmptyColor;
    public bool GrowFromLeft;
    private int MaxValue;
    public GameObject bar;
    public GameObject text;
    // Start is called before the first frame update

    private void Awake()
    {
        bar = transform.Find("Bar").gameObject;
        text = transform.Find("Text").gameObject;
    }

    void Start()
    {
        //SetProgress(StartPercentage, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //EventListener
    public void UpdateMax(int NewMax)
    {
        MaxValue = NewMax;
    }

    
    //EventListener
    public void UpdateCurrent(int NewCurrent)
    {
        float percentage = (float)NewCurrent / (float)MaxValue;
        bar.GetComponent<Image>().color = new Color(percentage * FullColor.r + (1 - percentage) * EmptyColor.r, percentage * FullColor.g + (1 - percentage) * EmptyColor.g, percentage * FullColor.b + (1 - percentage) * EmptyColor.b, 1);
        bar.transform.localScale = new Vector3(percentage * 1, 1, 1);
        if (GrowFromLeft)
        {
            bar.transform.localPosition = new Vector3((percentage - 1) / 2, 0, 0) * bar.GetComponent<RectTransform>().rect.width;
        }
    }

    public void SetProgress(float current, float max)
    {
        text.GetComponent<Text>().text = current.ToString() + " / " + max.ToString();
        float percentage = current / max;
        bar.GetComponent<Image>().color = new Color(percentage * FullColor.r + (1 - percentage) * EmptyColor.r, percentage * FullColor.g + (1 - percentage) * EmptyColor.g, percentage * FullColor.b + (1 - percentage) * EmptyColor.b, 1);
        bar.transform.localScale = new Vector3(percentage * 1, 1, 1);
        if (GrowFromLeft)
        {
            bar.transform.localPosition = new Vector3((percentage - 1) / 2, 0, 0) * bar.GetComponent<RectTransform>().rect.width;
        }
    }
}
