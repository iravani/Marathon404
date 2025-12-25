using UnityEngine;

public enum Axis
{
    Y, X
}
public enum Sign
{
    Pos, Neg
}

public class ForceField : MonoBehaviour
{
    public Axis axis;
    public Sign sign;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(axis == Axis.X)
        {
            if(sign == Sign.Neg)
            {
                collision.gameObject.GetComponent<PlayerMovement>().velocityOffset.x = -1;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerMovement>().velocityOffset.x = 1;
            }
        }
        else
        {
            if (sign == Sign.Neg)
            {
                collision.gameObject.GetComponent<PlayerMovement>().velocityOffset.y = -1;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerMovement>().velocityOffset.y = 1;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerMovement>().velocityOffset = Vector2.zero;
    }
}
