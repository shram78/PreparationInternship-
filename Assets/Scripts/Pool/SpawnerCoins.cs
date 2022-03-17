using UnityEngine;

public class SpawnerCoins : ObjectsPool
{
    [SerializeField] private GameObject[] _template;
    [SerializeField] private Transform[] _spawnPoint;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
            if (TryGetObject(out GameObject coin))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoint.Length);

                SetCoin(coin, _spawnPoint[spawnPointNumber].position);
            }
    }

    private void SetCoin(GameObject coin, Vector3 spawnPoint)
    {
        coin.SetActive(true);
        coin.transform.position = spawnPoint;
    }
}
