using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minrange;
    public float maxrange;
    public float interval;
    private int stage;
    public GameObject[] EnemyPrefab;
    public GameObject player;
    private float timer;
    public float enemyLimit;
    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            if (transform.childCount < enemyLimit)
            {
                timer = 0;
                SpawnEnemy();
            }
        }
    }

    public void AdvanceStage()
    {
        stage++;
    }

    private void SpawnEnemy()
    {
        float angle = Random.Range(0, 360);
        float distance = Random.Range(minrange, maxrange);
        Vector3 randomDir = Quaternion.Euler(0f, 0f, Random.Range(0, 360)) * Vector3.right * distance;
        Instantiate(EnemyPrefab[Random.Range(0, stage + 1)], player.transform.position + randomDir, new Quaternion(0, 0, 0, 0), this.transform);
    }
}
