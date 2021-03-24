using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public float speed;
    public float duration;
    private float timer;
    public float Xvariance;
    // Start is called before the first frame update
    void Start()
    {

        //transform.localPosition = new Vector3(0, 0, 0);
        float randomDif = Random.Range(-Xvariance, Xvariance);
        transform.Translate(Vector3.right * randomDif);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
        if(timer > duration)
        {
            Destroy(gameObject);
        }
    }
}
