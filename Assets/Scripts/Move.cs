﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 mousePosition;
    private Fish Fish;
    // Start is called before the first frame update
    void Start()
    {
        Fish = this.GetComponent<Fish>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 direction = Vector3.Normalize(mousePosition - this.transform.position);
            this.transform.position += direction * Fish.GetSpeed() * Time.deltaTime;
        }
        
    }
}