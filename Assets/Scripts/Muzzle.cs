using UnityEngine;

public class Muzzle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<EnemyAtra>().Die();
        }
    }
}
