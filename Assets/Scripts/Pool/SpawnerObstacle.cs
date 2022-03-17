using UnityEngine;

public class SpawnerObstacle : ObjectsPool
{
    [SerializeField] private GameObject[] _template;
    [SerializeField] private GameObject _previous;
    [SerializeField] private Transform _spawnPoint;

    private float _minDdistance = 1.5f;
    private float _maxDistance = 13.5f;
    private float _currentDistance;
    private float _previousWidth;
    private float _currentWidth;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        if (transform.position.x < _spawnPoint.position.x)
        {
            if (TryGetObject(out GameObject obstacles))
            {
                GetSize(obstacles);

                transform.position = new Vector3(transform.position.x + (_previousWidth / 2 + _currentWidth / 2) + _currentDistance, transform.position.y, transform.position.z);

                SetObstacle(obstacles, transform.position);

                _previous = obstacles;
            }
        }
    }

    private void GetSize(GameObject obstacles)
    {
        _previousWidth = _previous.transform.localScale.x;
        _currentWidth = obstacles.transform.localScale.x;
        _currentDistance = Random.Range(_minDdistance, _maxDistance);
    }

    private void SetObstacle(GameObject obstacle, Vector3 spawnPoint)
    {
        obstacle.GetComponent<Rigidbody2D>().isKinematic = true;

        obstacle.SetActive(true);

        obstacle.transform.position = spawnPoint;
    }
}
