using UnityEngine;

public class CamBackGround : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    public Color lightColor;
    public Color darkColor;

    [Range(0, 1)]
    public float switchToDark;

    private void Update()
    {
        if (player.position.x < 21)
        {
            switchToDark = (1f / 35f) * player.transform.position.y + (1f / 7f);
            cam.backgroundColor = Color.Lerp(darkColor, lightColor, switchToDark);
        }
    }
}
