using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public GameObject player;
    public float size = 100.0f;
    private float timer;
    public float updateTime;
    private Color BackgroundColor;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void updateBackgroundPosition()
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;

        if(playerX - transform.position.x > (size / 2))
        {
            transform.Translate(new Vector3(size, 0, 0));
            UpdateColor();
        } else if (transform.position.x - playerX > (size / 2))
        {
            transform.Translate(new Vector3(-size, 0, 0));
        }

        if (playerY - transform.position.y > (size / 2))
        {
            transform.Translate(new Vector3(0, size, 0));
        }
        else if (transform.position.y - playerY > (size / 2))
        {
            transform.Translate(new Vector3(0, -size, 0));
        }

    }

    void UpdateColor()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(0).gameObject;
            //Get the Renderer component from the new cube
            var renderer = child.GetComponent<Renderer>();

            //Call SetColor using the shader property name "_Color" and setting the color to red
            renderer.material.SetColor("_Color", Color.red);
        }
    }
}
