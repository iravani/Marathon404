using UnityEngine;

enum ParallaxType
{
    x,
    y,
    xy
}
public class Parallax : MonoBehaviour
{
    #region inspector vars
    [SerializeField] Transform camera;

    [SerializeField] ParallaxType parallaxType;

    [Range(-1f, 1f)]
    [SerializeField] float impact = 0;

    #endregion

    #region hidden vars
    Vector2 speed = Vector2.zero;

    Vector2 camera_last_position = Vector2.zero;
    Vector2 camera_current_position = Vector2.zero;
    #endregion

    #region MonoBehaviour funcs
    private void Start()
    {
        if (camera == null) camera = Camera.main.transform;

        setup_camera_positions_in_start();
    }

    private void FixedUpdate()
    {
        set_camera_s_current_position();
        calculate_camera_move_speed();

        move_the_object();

        set_camera_s_last_position();
    }
    #endregion

    #region defined funcs
    void setup_camera_positions_in_start()
    {
        camera_last_position = camera.position;
        camera_current_position = camera.position;
    }

    void set_camera_s_current_position()
    {
        camera_current_position = camera.position;
    }

    void set_camera_s_last_position()
    {
        camera_last_position = camera_current_position;
    }

    void calculate_camera_move_speed()
    {
        speed = (camera_current_position - camera_last_position) / Time.fixedDeltaTime;

        if (parallaxType == ParallaxType.x) speed.y = 0;
        else if (parallaxType == ParallaxType.y) speed.x = 0;
    }

    void move_the_object()
    {
        gameObject.transform.Translate(speed * Time.fixedDeltaTime * impact);
    }
    #endregion
}
