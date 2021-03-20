using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector3 direction;
    public int damage;
    public float duration;
    public float speed;
    public bool persistant;
    private float age;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
        if(age > duration)
        {
            Destroy(gameObject);
        }
        gameObject.transform.position += direction * speed * Time.deltaTime;
    }

    public void Initialise(Vector3 direction)
    {
        this.direction = direction;
        RotateToTangent();
    }

    private void RotateToTangent()
    {

        float z = Vector3.SignedAngle(Vector3.up, this.direction, Vector3.forward);
        Quaternion rotation = Quaternion.Euler(0, 0, z);

        transform.rotation = rotation;
    }
}
