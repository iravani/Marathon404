using UnityEngine;

public class PointerMovement : MonoBehaviour
{
    Vector3 mouseWorldPos;
    private void Update()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        gameObject.transform.position = mouseWorldPos;
    }
}
