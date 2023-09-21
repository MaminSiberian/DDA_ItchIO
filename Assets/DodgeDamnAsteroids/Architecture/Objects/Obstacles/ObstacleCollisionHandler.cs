using UnityEngine;

public class ObstacleCollisionHandler : MonoBehaviour
{
    private string playerTag = TagStorage.playerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            this.gameObject.SetActive(false);
        }
    }
}
