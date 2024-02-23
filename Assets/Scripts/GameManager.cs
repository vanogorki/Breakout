using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _paddle;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _brick;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _healthBar;
    
    private int _health = 3;
    private Camera _camera;
    private bool _isOffScreen;
    private bool _isSpawning;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
        _camera = Camera.main;
        // spawn paddle
        Instantiate(_paddle, new Vector3(0, -4f, 0), Quaternion.identity);
        // spawn ball
        StartCoroutine(SpawnBall());
        // spawn bricks
        for (float i = 0; i < 5f; i += 0.5f)
        {
            for (float j = 0; j < 16.5f; j += 1.5f)
            {
                Instantiate(_brick, new Vector3(j - 7.5f, 4f - i, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var ballPosition = _camera.WorldToScreenPoint(_ball.transform.position);
        _isOffScreen = ballPosition.y < 0;
        
        if (_isOffScreen && _health > 0 && !_isSpawning)
        {
            Debug.Log("Ball is off screen!");
            _health--;
            _healthBar.GetComponent<IconHandler>().UpdateIcons(_health);
            
            if (_health == 0)
                GameOver();
            else
                StartCoroutine(SpawnBall());
        }
    }

    private IEnumerator SpawnBall()
    {
        _isSpawning = true;
        float randomX = Random.Range(-7.5f, 7.5f);
        yield return new WaitForSeconds(1);
        _ball = Instantiate(_ball, new Vector3(randomX, -3.9f, 0), Quaternion.identity);
        _isSpawning = false;
    }
    
    private void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}