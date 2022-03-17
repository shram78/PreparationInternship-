using UnityEngine;

public class SpawnerCoins : ObjectsPool
{
    [SerializeField] private GameObject[] _coinPrefab;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private float _secondsBetweenSpawn;

    //private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_coinPrefab);
    }

    private void Update()
    {
       // _elapsedTime += Time.deltaTime;

       // if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject coin))
            {
          //      _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoint.Length);

                SetCoin(coin, _spawnPoint[spawnPointNumber].position);
            }
        }
    }

    private void SetCoin(GameObject coin, Vector3 spawnPoint)
    {
        coin.SetActive(true);
        coin.transform.position = spawnPoint;
    }
}
