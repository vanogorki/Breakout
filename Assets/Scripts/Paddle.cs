using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _inputAction;
    private Camera _camera;
    private float _paddleHalfWidth;
    private float _cameraHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _paddleHalfWidth = GetComponent<Collider2D>().bounds.size.x / 2;
        
        _inputAction = _playerInput.actions["MousePosition"];
        _camera = Camera.main;
        _cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(_inputAction.ReadValue<Vector2>());
        transform.position = new Vector2(mousePos.x, transform.position.y);
        
        // check if the paddle is within camera bounds
        float x = Mathf.Clamp(transform.position.x, -_cameraHalfWidth + _paddleHalfWidth, _cameraHalfWidth - _paddleHalfWidth);
        transform.position = new Vector2(x, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // calculate where the ball hit the paddle and change the direction of the ball
            Vector2 hitPoint = other.GetContact(0).point;
            Vector2 paddleCenter = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = hitPoint - paddleCenter;
            var speed = other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
            
            SoundManager.Instance.PlayPaddleHit();
        }
    }
}