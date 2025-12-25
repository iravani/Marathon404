using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;
    public float speed;
    public Vector2 velocityOffset;
    public float velocityForceFieldAdder = 20;
    public SpriteRenderer playerGraphics;
    public ParticleSystem bubbles;

    [Header("Attack")]
    public GameObject projectile;
    public Transform mousePointer;
    public float attackProjectileSpeed;
    public float attckDestroyTime = 0.5f;
    public float timeToResetTimeScale = 0.1f;

    float timer = 0;

    Vector2 moveDirection;
    bool wentOut = false;


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
            if(moveDirection.x > 0)
            {
                playerGraphics.flipX = true;
            }else if (moveDirection.x < 0)
            {
                playerGraphics.flipX = false;

            }
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
        if(wentOut && transform.position.y < 26)
        {
            bubbles.Play();
            wentOut = false;
            wentOut = false;
        }
    }

    private void Move()
    {
        rb.linearVelocity = moveDirection * speed + velocityOffset * velocityForceFieldAdder;
    }

    void Attack()
    {
        if(mousePointer.position.x > gameObject.transform.position.x)
        {
            playerGraphics.flipX = true;
        }
        else if(mousePointer.position.x < gameObject.transform.position.x)
        {
            playerGraphics.flipX = false;
        }
        GameObject attackEffect = Instantiate(projectile);
        attackEffect.transform.position = gameObject.transform.position;
        Vector2 attackDirection = mousePointer.position - gameObject.transform.position;
        attackDirection.Normalize();
        Rigidbody2D attackEffectRigidbody = attackEffect.GetComponent<Rigidbody2D>();
        attackEffectRigidbody.linearVelocity = attackDirection * attackProjectileSpeed;
        attackEffectRigidbody.rotation = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        Destroy(attackEffect, attckDestroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            Die();
        }
        else if(collision.gameObject.tag == "Bound")
        {
            wentOut = true;
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }
}
