using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerPositions;
    public Transform playerVisual;
    public GameObject velocityParticles;
    
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 8.0f;
    
    private int _currentPosition = 0;
    private float _currentRotation = 0.0f;

    private bool _particlesActive = false;
    
    private void Start()
    {
        velocityParticles.SetActive(false);
    }

    private void Update()
    {
        CheckVerticalMovement();
        CheckForWheelie();
    }

    private void CheckVerticalMovement()
    {
        bool up = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        bool down = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
        
        if (up)
            _currentPosition += 1;
        else if (down)
            _currentPosition -= 1;
        
        _currentPosition = Mathf.Clamp(_currentPosition, 0, playerPositions.childCount - 1);
        
        Transform positionTransform = playerPositions.GetChild(_currentPosition);
        transform.position = Vector3.Lerp(transform.position, positionTransform.position, movementSpeed * Time.deltaTime);
    }

    private void CheckForWheelie()
    {
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        
        if (left)
        {
            _currentRotation += rotationSpeed * Time.deltaTime;
            if (!_particlesActive)
            {
                _particlesActive = true;
                velocityParticles.SetActive(true);
            }
        }
        else
        {
            _currentRotation -= (rotationSpeed * 2) * Time.deltaTime;
            if (_currentRotation < 0.1f && _particlesActive)
            {
                _particlesActive = false;
                velocityParticles.SetActive(false);
            }
        }
        
        _currentRotation = Mathf.Clamp(_currentRotation, 0, 25.0f);
        transform.eulerAngles = new Vector3(0.0f, 0.0f, _currentRotation);
    }
}
