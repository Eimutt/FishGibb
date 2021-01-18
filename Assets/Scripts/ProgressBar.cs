using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Image Sprite;
    private Text ProgressText;
    public float StartValue;
    public Color FullColor;
    public Color EmptyColor;
    public bool GrowFromLeft;
    private int MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<Image>();
        ProgressText = GetComponentInChildren<Text>();
        SetProgress(StartValue, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //EventListener
    public void UpdateMax(int NewMax)
    {
        MaxValue = NewMax;
        print(MaxValue);
    }

    
    //EventListener
    public void UpdateCurrent(int NewCurrent)
    {
        float percentage = (float)NewCurrent / (float)MaxValue;
        Sprite.color = new Color(percentage * FullColor.r + (1 - percentage) * EmptyColor.r, percentage * FullColor.g + (1 - percentage) * EmptyColor.g, percentage * FullColor.b + (1 - percentage) * EmptyColor.b, 1);
        transform.localScale = new Vector3(percentage * 1, 1, 1);
        if (GrowFromLeft)
        {
            print(percentage);
            transform.localPosition = new Vector3((percentage - 1) / 2, 0, 0) * this.GetComponent<RectTransform>().rect.width;
        }
    }

    public void SetProgress(float current, float max)
    {
        float percentage = current / max;
        Sprite.color = new Color(percentage * FullColor.r + (1 - percentage) * EmptyColor.r, percentage * FullColor.g + (1 - percentage) * EmptyColor.g, percentage * FullColor.b + (1 - percentage) * EmptyColor.b, 1);
        transform.localScale = new Vector3(percentage * 1, 1, 1);
        if (GrowFromLeft)
        {
            transform.localPosition = new Vector3((percentage - 1) / 2, 0, 0) * this.GetComponent<RectTransform>().rect.width;
        }
    }
}
