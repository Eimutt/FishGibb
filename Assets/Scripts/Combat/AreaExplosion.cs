using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaExplosion : MonoBehaviour
{
    private int damage;
    private float radius;
    private float lifetime;
    private float age;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
        float size = 1 + (radius - 1) * (age / lifetime);
        transform.localScale = new Vector3(size, size, size);

        Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        transform.rotation = rotation;

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, (1 - age / lifetime));

        if (age >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void Initialise(int damage, float radius, float lifetime)
    {
        this.damage = damage;
        this.radius = radius;
        this.lifetime = lifetime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            //Enemies cause new explosion if they die
            if (!(enemy.GetCurrentHp() > 0))
            {
                GameObject explostionObj = Instantiate(this.gameObject, collision.transform.position, new Quaternion(0, 0, 0, 0), GameObject.Find("BulletManager").transform);
                AreaExplosion explosion = explostionObj.GetComponent<AreaExplosion>();
                explosion.Initialise(this.damage / 2, this.radius / 2, this.lifetime);
            }
        }
    }
}
