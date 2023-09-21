
using UnityEngine;

public class Asteroid : Obstacle
{
    private string bombTag = TagStorage.bombTag;
    private string playerTag = TagStorage.playerTag;
    private string destructionTag = TagStorage.asterDestruction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(bombTag) || collision.CompareTag(playerTag))
            BlowUp();
    }
    public void BlowUp()
    {
        var obj = PoolManager.GetObject(destructionTag);
        obj.transform.position = this.transform.position;

        SoundsManager.PlayCrushSound();
        this.gameObject.SetActive(false);
    }
}
