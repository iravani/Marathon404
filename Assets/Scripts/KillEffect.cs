using UnityEngine;

public class KillEffect : MonoBehaviour
{
    public float destroyTime = .5f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
