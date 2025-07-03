using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    public Obstacle obstaclePrefab;
    public Transform obstacleSpawner;
    public Transform despawnTransform;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 4.0f, 2.0f);
    }

    private void Update()
    {
        foreach (Transform obst in transform)
        {
            obst.position -= obst.right * (_gameManager.GameSpeed * Time.deltaTime);
            
            if (obst.position.x < despawnTransform.position.x)
                Destroy(obst.gameObject);
        }
    }

    void SpawnObstacle()
    {
        Obstacle obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        if (!obstacle) return;
        obstacle.transform.parent = transform;
        obstacle.transform.position = obstacleSpawner.GetChild(Random.Range(0,2)).position;
    }
}
