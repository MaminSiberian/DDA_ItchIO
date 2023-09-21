using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    private static Animator anim;
    private static string animationName = "Shake";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public static void ShakeCamera()
    {
        anim.Play(animationName);
    }
}
