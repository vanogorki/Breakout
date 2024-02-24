using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    
    [SerializeField] private AudioClip _ballBounce;
    [SerializeField] private AudioClip _brickHit;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _gameOver;
    [SerializeField] private AudioClip _levelComplete;
    
    private AudioSource _audioSource;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        _audioSource.Play();
    }
    
    public void PlayBallBounce()
    {
        _audioSource.PlayOneShot(_ballBounce);
    }
    
    public void PlayBrickHit()
    {
        _audioSource.PlayOneShot(_brickHit);
    }
    
    public void PlayPaddleHit()
    {
        _audioSource.PlayOneShot(_paddleHit);
    }
    
    public void PlayGameOver()
    {
        _audioSource.PlayOneShot(_gameOver);
    }
    
    public void PlayLevelComplete()
    {
        _audioSource.PlayOneShot(_levelComplete);
    }
}
