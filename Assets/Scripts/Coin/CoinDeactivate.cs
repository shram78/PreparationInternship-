using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDeactivate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ObstacleKillZone destroyerObstacles))
        {
            gameObject.SetActive(false);

            ActivateChild();
        }
    }

    private void ActivateChild()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
