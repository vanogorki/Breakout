using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;
    
    private bool _isOffScreen;
    private Camera _camera;
    
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value, 1) * _speed;
        _camera = Camera.main;
    }

    void Update()
    {
        var ballPosition = _camera.WorldToScreenPoint(transform.position);
        _isOffScreen = ballPosition.y < 0;

        if (_isOffScreen)
        {
            GameManager.Instance.BallOffScreen();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Border"))
            SoundManager.Instance.PlayBallBounce();
    }
}
