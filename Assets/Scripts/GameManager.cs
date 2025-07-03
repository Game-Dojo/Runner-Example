using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Main Refs")]
    [SerializeField] private Transform background;
    [SerializeField] private ParticleSystem speedParticles;
    
    [Header("Properties")]
    [SerializeField] private float gameSpeed = 5f;
    [SerializeField] private bool gameOver = false;

    private const float LeftLimit = -18.0f;
    
    private void Update()
    {
        if (gameOver) return;
        
        background.position -= transform.right * (gameSpeed * Time.deltaTime);
        
        if (background.position.x < LeftLimit)
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
