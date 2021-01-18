using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float minrange;
    public float maxrange;
    public float interval;
    public GameObject FoodPrefab;
    public GameObject player;
    private float timer;
    public float foodLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0;
            float angle = Random.Range(0, 360);
            float distance = Random.Range(minrange, maxrange);
            Vector3 randomDir = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector3.right * distance;
            Instantiate(FoodPrefab, player.transform.position + randomDir, new Quaternion(0, 0, 0, 0), this.transform);
        }
    }
}
