using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedBullet : MonoBehaviour
{
    public Vector3 origin;
    public Vector3 midpoint;
    public Vector3 targetPos;
    public float speed;
    private float t;
    public GameObject target;
    private int damage;
    public Animator animator;
    public Sprite explosionAnimation;
    public float fadeoutDuration;
    public float fadeoutTimer;
    private SpriteRenderer spriteRenderer;

    private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        fadeoutTimer = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            fadeoutTimer += Time.deltaTime;
            float r = (fadeoutTimer / fadeoutDuration);
            spriteRenderer.color = startColor - new Color(0, 0, 0, r);
            if (fadeoutTimer >= fadeoutDuration)
                Destroy(this.gameObject);
        }
        else
        {
            targetPos = target.transform.position;
        }
        transform.position = Mathf.Pow((1 - t), 2) * origin + 2 * (1 - t) * t * midpoint + Mathf.Pow(t, 2) * targetPos;
        t += speed * Time.deltaTime;
        RotateToTangent();

        if (t > 1)
        {
            Explode();
        }
        
    }

    public void Initialise(int damage, float speed, GameObject target)
    {
        this.origin = this.transform.position;
        this.damage = damage;
        this.target = target;
        this.speed = speed;
        CalculateMidPoint();


        //target.GetComponent<Enemy>().IncreaseIncomingDamage(damage);
    }

    private void CalculateMidPoint()
    {
        targetPos = target.transform.position;
        Vector3 middle = (targetPos + origin) / 2;
        float distance = Vector3.Distance(targetPos, origin);

        Vector3 normalized = Vector3.Normalize(targetPos - origin);
        Vector3 turned = Quaternion.Euler(0, 0, 90) * normalized;

        midpoint = middle + turned * Random.Range(-distance / 2, distance / 2);



    }

    //tangent to bezier curve
    private void RotateToTangent()
    {
        Vector3 direction = 2 * (1 - t) * (midpoint - origin) + 2 * t * (targetPos - midpoint);

        float z = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
        Quaternion rotation = Quaternion.Euler(0, 0, z);

        transform.rotation = rotation;
    }

    //Sets object to inactive and starts the explosion animation
    private void Explode()
    {
        target.GetComponent<Unit>().TakeDamage(damage);
        spriteRenderer.sprite = explosionAnimation;
        this.transform.localScale = transform.localScale * 1.8f;
        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359f));

        animator.SetTrigger("Destroy");
        Destroy(gameObject, 0.15f);
        this.enabled = false;
    }
}
