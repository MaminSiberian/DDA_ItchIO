using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    protected float maxX = 4;
    protected float maxY = 8;

    protected virtual void Update()
    {
        CheckObjPosition();
    }

    protected void CheckObjPosition()
    {
        if (Mathf.Abs(this.transform.position.x) >= maxX || Mathf.Abs(this.transform.position.y) >= maxY)
            TurnOffObject();
    }
    public void TurnOffObject()
    {
        this.gameObject.SetActive(false);
    }
}
