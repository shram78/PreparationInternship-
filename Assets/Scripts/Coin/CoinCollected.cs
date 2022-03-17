using UnityEngine;

public class CoinCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.AddScore();

            gameObject.SetActive(false);
        }
    }
}
