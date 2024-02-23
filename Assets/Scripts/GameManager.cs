using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _paddlePrefab;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _brickPrefab;
    
    private int _health = 3;
    private Camera _camera;
    private bool _isOffScreen;


    // Start is called before the first frame update
    void Awake()
    {
        _camera = Camera.main;
        // spawn paddle
        Instantiate(_paddlePrefab, new Vector3(0, -4f, 0), Quaternion.identity);
        // spawn ball
        _ballPrefab = Instantiate(_ballPrefab, new Vector3(0, -3.9f, 0), Quaternion.identity);
        // spawn bricks
        for (float i = 0; i < 5f; i += 0.5f)
        {
            for (float j = 0; j < 16.5f; j += 1.5f)
            {
                Instantiate(_brickPrefab, new Vector3(j - 7.5f, 4f - i, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var ballPosition = _camera.WorldToScreenPoint(_ballPrefab.transform.position);
        var _isOffScreen = ballPosition.y < 0;
        if (_isOffScreen && _health > 0)
        {
            Debug.Log("Ball is off screen!");
            _health--;
            if (_health == 0)
            {
                Debug.Log("Game Over");
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            }
            else
                SpawnBall();
        }
    }

    private void SpawnBall()
    {
        _ballPrefab = Instantiate(_ballPrefab, new Vector3(0, -3.9f, 0), Quaternion.identity);
        _isOffScreen = false;
    }
}