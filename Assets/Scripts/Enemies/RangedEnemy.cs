using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public enum RangedAttackType
    {
        Pattern,
        Target,
        Circle
    }
    public RangedAttackType rangedType;
    public float range;
    public float rangedDamage;
    public float fireRate;
    private float reloadTime;
    public bool ActiveAim;
    public int shoots;
    public float spreadDegree;

    public float degreeLimit;
    public float degreeCount;
    public bool add;

    public float shotAngle;
    public GameObject shot;
    private bool FirstCombat = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (InCombat)
        {
            if (FirstCombat)
            {
                shotAngle = transform.Find("Sprite").rotation.eulerAngles.z;
                FirstCombat = false;
            }
            reloadTime += Time.deltaTime;
            if(reloadTime > (1 / fireRate))
            {
                Shoot();
                reloadTime = 0;
            }
        }
    }

    void Shoot()
    {
        switch (rangedType)
        {
            case RangedAttackType.Pattern:
            {
                shotAngle = transform.Find("Sprite").rotation.eulerAngles.z;

                for (int i = 0; i < shoots; i++)
                {
                    Vector3 dir = Quaternion.AngleAxis(shotAngle, Vector3.forward) * Vector3.up;
                    GameObject enemyBulletObj = Instantiate(shot, transform.position, new Quaternion(0, 0, 0, 0), GameObject.Find("BulletManager").transform);
                    EnemyBullet enBullet = enemyBulletObj.GetComponent<EnemyBullet>();
                    enBullet.Initialise(dir);
                    shotAngle += spreadDegree;
                }
                break;
            }
            case RangedAttackType.Circle:
            {
                Vector3 dir = Quaternion.AngleAxis(shotAngle, Vector3.forward) * Vector3.up;
                GameObject enemyBulletObj = Instantiate(shot, transform.position, new Quaternion(0, 0, 0, 0), GameObject.Find("BulletManager").transform);
                EnemyBullet enBullet = enemyBulletObj.GetComponent<EnemyBullet>();
                enBullet.Initialise(dir);

                //if (add)
                //    shotAngle += spreadDegree;
                //else
                //    shotAngle -= spreadDegree;
                shotAngle += spreadDegree * (add ? 1 : -1);
                degreeCount += spreadDegree;
                if(degreeCount > degreeLimit)
                {
                    degreeCount = 0;
                    add = !add;
                    shotAngle = transform.Find("Sprite").rotation.eulerAngles.z;
                }
                break;
            }
            default: break;
        }
    }
}
