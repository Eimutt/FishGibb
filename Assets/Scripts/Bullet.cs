using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    private float damage;
    private float speed;
    private float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
            Destroy(gameObject);
        else
        {
            transform.position += Vector3.Normalize(target.transform.position - transform.position) * speed * Time.deltaTime;
            if (Vector3.Distance(target.transform.position, transform.position) < 0.1f)
            {
                target.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    public void Initialise(float damage, float speed, GameObject target)
    {
        this.damage = damage;
        this.speed = speed;
        this.target = target;
    }
}
