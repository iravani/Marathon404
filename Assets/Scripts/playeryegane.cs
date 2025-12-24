using UnityEngine;

public class playeryegane : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
