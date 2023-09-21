using UnityEngine;

public class TouchInputHandler : MonoBehaviour, IInputHandler
{
    public float HorizontalSpeed()
    {
        return TouchInput.horizontalAxis;
    }
    public float VerticalSpeed()
    {
        return TouchInput.verticalAxis;
    }
}
