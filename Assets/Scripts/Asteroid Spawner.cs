
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroid;
    [SerializeField] private float _secondBetweenSpawn = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private float _time;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        _time = 0f;
    }

    private void Update()
    {
        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            SpawnAsteroid();
            _time += _secondBetweenSpawn;
        }
    }

    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);

        Vector3 spawnPoint = Vector3.zero;
        Vector3 direction = Vector3.zero;

        switch (side)
        {
            case 0: // up
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector3(Random.Range(-1f, 1f), 0f, -1f);
                break;
            case 1: // down
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector3(Random.Range(-1f, 1f), 0f, 1f);
                break;
            case 2: // left
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector3(1f, 0f, Random.Range(-1f, 1f));
                break;
            case 3: // right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector3(-1f, 0f, Random.Range(-1f, 1f));
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);

        GameObject asteroidInstance = Instantiate(_asteroid[Random.Range(0, _asteroid.Length)], worldSpawnPoint, Quaternion.Euler(0, Random.Range(0, 360), 90));
        Rigidbody rb = asteroidInstance.transform.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}

/*using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroid;
    [SerializeField] private float _secondBetweenSpawn = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private float _time;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        _time = 0f;
    }

    private void Update()
    {
        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            SpawnAsteroid();
            _time += _secondBetweenSpawn;
        }
    }

    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);

        Vector3 spawnPoint = Vector3.zero;
        Vector3 direction = Vector3.zero;

        switch (side)
        {
            case 0: // up
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector3(Random.Range(-1f, 1f), 0f, -1f);
                break;
            case 1: // down
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector3(Random.Range(-1f, 1f), 0f, 1f);
                break;
            case 2: // left
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector3(1f, 0f, Random.Range(-1f, 1f));
                break;
            case 3: // right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector3(-1f, 0f, Random.Range(-1f, 1f));
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);

        GameObject asteroidInstance = Instantiate(_asteroid[Random.Range(0, _asteroid.Length)], worldSpawnPoint, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}*/
