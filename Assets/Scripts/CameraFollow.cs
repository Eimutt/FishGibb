using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float cameraSize;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Camera>().orthographicSize = cameraSize;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + offset;
    }
}
