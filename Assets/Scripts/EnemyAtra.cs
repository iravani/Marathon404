using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyAtra : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 dir;
    public GameObject target;
    public float speed;
    public float error = 0.1f;
    public Animator camAnim;
    public SpriteRenderer spriteRenderer;
    public GameObject killEffect;


    private void Start()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        dir = target.transform.position - gameObject.transform.position;
        if (dir.magnitude > error)
        {
            rb.linearVelocity = dir.normalized * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (rb.linearVelocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }else if (rb.linearVelocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }

    }

    public void Die()
    {
        camAnim.SetTrigger("Shake");
        Time.timeScale = 0.3f;

        GameObject effect = Instantiate(killEffect);
        effect.transform.position = gameObject.transform.position;
        float rot = Mathf.Atan2(target.transform.position.y - gameObject.transform.position.y,target.transform.position.x - gameObject.transform.position.x) * Mathf.Rad2Deg;
        effect.GetComponent<Rigidbody2D>().rotation = rot;
        gameObject.SetActive(false);
    }
    
}