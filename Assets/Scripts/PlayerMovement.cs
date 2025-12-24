using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;
    public float speed;

    [Header("Attack")]
    public GameObject projectile;
    public Transform mousePointer;
    public float attackProjectileSpeed;
    public float attckDestroyTime = 0.5f;
    public float timeToResetTimeScale = 0.1f;

    float timer = 0;

    Vector2 moveDirection;

    private void Update()
    {
        if(Time.timeScale != 1)
        {
            timer += Time.deltaTime;
            if(timer >= timeToResetTimeScale)
            {
                timer = 0;
                Time.timeScale = 1;
            }
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            moveDirection.x = Input.GetAxisRaw("Horizontal");
            moveDirection.y = Input.GetAxisRaw("Vertical");
            moveDirection.Normalize();
        }
        else
        {
            moveDirection = Vector2.zero;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = moveDirection * speed;
    }

    void Attack()
    {
        GameObject attackEffect = Instantiate(projectile);
        attackEffect.transform.position = gameObject.transform.position;
        Vector2 attackDirection = mousePointer.position - gameObject.transform.position;
        attackDirection.Normalize();
        Rigidbody2D attackEffectRigidbody = attackEffect.GetComponent<Rigidbody2D>();
        attackEffectRigidbody.linearVelocity = attackDirection * attackProjectileSpeed;
        attackEffectRigidbody.rotation = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        Destroy(attackEffect, attckDestroyTime);
    }
}
