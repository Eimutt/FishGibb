using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public GameObject player;
    public float size = 100.0f;
    private float timer;
    public float updateTime;
    public Color backgroundColor;
    public Color targetColor;
    private bool changingColor;
    private float colorChangeDur;
    private float colorChangeTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartChangeColor(0, targetColor);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > updateTime)
        {
            updateBackgroundPosition();
            timer = 0;
        }

        if (changingColor)
        {
            colorChangeTimer += Time.deltaTime;
            ChangeColor(colorChangeTimer / colorChangeDur);
            if(colorChangeTimer > colorChangeDur)
            {
                colorChangeTimer = 0;
                changingColor = false;
                backgroundColor = targetColor;
            }
        }
    }

    void updateBackgroundPosition()
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;

        if(playerX - transform.position.x > (size / 2))
        {
            transform.Translate(new Vector3(size, 0, 0));
            StartChangeColor(3, ColorsStruct.Green);
        } else if (transform.position.x - playerX > (size / 2))
        {
            transform.Translate(new Vector3(-size, 0, 0));
            StartChangeColor(3, ColorsStruct.Pink);
        }

        if (playerY - transform.position.y > (size / 2))
        {
            transform.Translate(new Vector3(0, size, 0));
            StartChangeColor(3, ColorsStruct.Blue);
        }
        else if (transform.position.y - playerY > (size / 2))
        {
            transform.Translate(new Vector3(0, -size, 0));
            StartChangeColor(3, ColorsStruct.Orange);
        }

    }

    void StartChangeColor(float duration, Color targetColor)
    {
        this.targetColor = targetColor;
        changingColor = true;
        colorChangeDur = duration;
    }

    void ChangeColor(float percentage)
    {

        Color lerpedColor = Color.Lerp(backgroundColor, targetColor, percentage);


        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            //Get the Renderer component from the new cube
            var renderer = child.GetComponent<Renderer>();

            //Call SetColor using the shader property name "_Color" and setting the color to red
            renderer.material.SetColor("_Color", lerpedColor);
        }
    }
}
