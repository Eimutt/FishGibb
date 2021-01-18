using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    private SpriteRenderer Sprite;
    private Text ProgressText;
    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        ProgressText = GetComponentInChildren<Text>();
        SetProgress(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProgress(float current, float max)
    {
        float Percentage = current/max;
        //sprite.color = new Color(1 - percentage, percentage, 0, 1);
        transform.localScale = new Vector3(Percentage* 2000, 500, 1);
        //transform.localPosition = new Vector3((percentage-1)/2 * 2000, -200, 0) * 0.3f;
    }
}
