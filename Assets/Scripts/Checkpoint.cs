using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject player;
    private GameObject gameState;
    private GameObject canvas;
    public float saveInterval;
    private float timer;
    private bool init = false;
    // Start is called before the first frame update
    void Start()
    {
        //player = new GameObject();
        //gameState = new GameObject();
        //canvas = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > saveInterval)
        {
            timer = 0;
            SaveCheckpoint();
        }

        if (Input.GetKeyDown("space"))
        {
            GoToPreviousCheckpoint();
        }
    }

    void SaveCheckpoint()
    {
        if (init)
        {
            Destroy(player);
            Destroy(gameState);
            Destroy(canvas);
        }
        player = Instantiate(GameObject.Find("Fish"));
        player.SetActive(false);
        gameState = Instantiate(GameObject.Find("GameHandler"));
        gameState.SetActive(false);
        canvas = Instantiate(GameObject.Find("Canvas"));
        canvas.SetActive(false);
        init = true;
    }

    void GoToPreviousCheckpoint()
    {
        GameObject c = GameObject.Find("Fish");
        c.transform.position = player.transform.position;
        //c.AddComponent<Fish>()

    }
}
