using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Vector3 RandomDirection;
    private bool Patrolling;
    private float timer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        if (Patrolling)
        {
            transform.position += RandomDirection * speed * Time.deltaTime;
            timer += Time.deltaTime;
            if (timer > 3)
            {
                Patrolling = false;
                timer = 0;
            }
        }
        else
        {
            GetRandomDirection();
        }
    }

    public void GetRandomDirection()
    {
        RandomDirection = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector3.right;
        Patrolling = true;
    }
}
