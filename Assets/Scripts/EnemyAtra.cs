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

    }

    public void Die()
    {
        camAnim.SetTrigger("Shake");
        Time.timeScale = 0.3f;
        gameObject.SetActive(false);
    }
    
}