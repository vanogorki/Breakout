using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _healthBar;
    
    private int _health = 3;
    private bool _isLevelComplete;
    private bool _isOneBallLeft;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        // spawn paddle
        SpawnManager.Instance.SpawnPaddle();
        // spawn ball
        StartCoroutine(SpawnBallAfterTime());
        // spawn bricks
        for (float i = 0; i < 5f; i += 0.5f)
        {
            for (float j = 0; j < 16.5f; j += 1.5f)
            {
                SpawnManager.Instance.SpawnRandomBrick(new Vector3(j - 7.5f, 4f - i, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0 && !_isLevelComplete)
        {
            StartCoroutine(LevelComplete());
            return;
        }

        if (GameObject.FindGameObjectsWithTag("Ball").Length == 1)
            _isOneBallLeft = true;
        else
            _isOneBallLeft = false;
    }
    
    private IEnumerator SpawnBallAfterTime()
    {
        yield return new WaitForSeconds(1);
        float randomX = Random.Range(-7.5f, 7.5f);
        SpawnManager.Instance.SpawnBall(new Vector3(randomX, -3.9f, 0));
    }

    private IEnumerator LevelComplete()
    {
        _isLevelComplete = true;
        SoundManager.Instance.PlayLevelComplete();
        yield return new WaitForSeconds(3);
        RestartGame();
    }
    
    private void GameOver()
    {
        SoundManager.Instance.PlayGameOver();
        _gameOverScreen.SetActive(true);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void BallOffScreen()
    {
        if (_health > 0 && !_isLevelComplete && _isOneBallLeft)
        {
            _health--;
            _healthBar.GetComponent<IconHandler>().UpdateIcons(_health);
            
            if (_health == 0)
                GameOver();
            else
                StartCoroutine(SpawnBallAfterTime());
        }
    }
}