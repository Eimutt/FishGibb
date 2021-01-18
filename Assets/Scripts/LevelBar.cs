using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBar : MonoBehaviour
{
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetProgress(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProgress(float current, float max)
    {
        float percentage = current/max;
        //sprite.color = new Color(1 - percentage, percentage, 0, 1);
        transform.localScale = new Vector3(percentage* 2000, 200, 1);
        //transform.localPosition = new Vector3((percentage-1)/2 * 2000, -200, 0) * 0.3f;
    }
}
