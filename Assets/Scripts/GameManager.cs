using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform background;
    public float gameSpeed = 3f;
    public ParticleSystem speedParticles;
    public bool gameOver = false;

    private void Update()
    {
        if (gameOver) return;
        
        background.position -= transform.right * (gameSpeed * Time.deltaTime);
        
        if (background.position.x < -18.0f)
            background.position = new Vector3(0, background.position.y, background.position.z);
    }

    public void IncreaseSpeed()
    {
        gameSpeed += 1.0f;
        var main = speedParticles.main;
        main.simulationSpeed += 0.3f;
    }

    public float GameSpeed => gameSpeed;
}
