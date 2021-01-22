using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public float speed;
    public float limit;
    public float Xvariance;
    // Start is called before the first frame update
    void Start()
    {

        transform.localPosition = new Vector3(0, 0, 0);
        float randomDif = Random.Range(-Xvariance, Xvariance);
        transform.localPosition = (transform.localPosition) + new Vector3(randomDif, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = transform.localPosition + new Vector3(0, speed * Time.deltaTime, 0);
        print(transform.localPosition);
        if(transform.localPosition.y > limit)
        {
            Destroy(gameObject);
        }
    }
}
