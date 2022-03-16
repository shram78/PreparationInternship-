using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            gameObject.SetActive(false);

            Debug.Log("PLAYER");
        }


        if (collision.gameObject.TryGetComponent(out ObstacleKillZone destroyerObstacles))
        {
            gameObject.SetActive(false);
            Debug.Log("Kill");
        }
    }
}
