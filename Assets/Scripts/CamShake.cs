using System.Collections;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animator anim;
    public static CamShake camShake;

    void Awake()
    {
        if(camShake == null)
            camShake = this;
    }

    public void Shake()
    {
        anim.SetTrigger("Shake");
    }

    public IEnumerator resetTimeScale()
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 1;
    }
}
