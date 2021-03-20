using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeSpawner : MonoBehaviour
{
    public GameObject shot;
    public float fireRate;
    private float reloadTime;
    public float radius;
    public int damage;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        reloadTime += Time.deltaTime;
        if (reloadTime > (1 / fireRate))
        {
            Shoot();
            reloadTime = 0;
        }
    }

    private void Shoot()
    {
        GameObject explostionObj = Instantiate(shot, transform.position, new Quaternion(0, 0, 0, 0), GameObject.Find("BulletManager").transform);
        AreaExplosion explosion = explostionObj.GetComponent<AreaExplosion>();
        explosion.Initialise(this.damage, this.radius, this.lifetime);
    }
}
