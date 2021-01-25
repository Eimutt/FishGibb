using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedGun : MonoBehaviour
{
    public GameObject shot;
    private GameObject target;
    public float fireRate;
    private float reloadTime;
    public float range;
    public int damage;
    public float speed;
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
            if (target)
            {
                if (IsTargetInRange())
                    Shoot();
                else
                    target = null;
            }
            else
            {
                GetNewTarget();
            }
            reloadTime = 0;
        }

    }

    private void GetNewTarget()
    {
        float minDistance = range;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < minDistance)
            {
                target = enemy;
                minDistance = enemyDistance;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(shot, transform.position, new Quaternion(0, 0, 0, 0), GameObject.Find("BulletManager").transform);
        CurvedBullet curvedBullet = bulletObj.GetComponent<CurvedBullet>();
        curvedBullet.Initialise(this.damage, this.speed, this.target);
    }

    private bool IsTargetInRange()
    {
        return (Vector3.Distance(transform.position, target.transform.position) < range);
    }
}
