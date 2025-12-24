using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [Range(0, 1)]
    public float camSmooth;
    public GameObject target;
    public Vector3 offset;
    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.transform.position + offset, camSmooth);
    }
}
