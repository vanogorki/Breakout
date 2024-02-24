using UnityEngine;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour
{
    [SerializeField] private Sprite _damagedSprite;
    [SerializeField] private GameObject _particles;

    private void OnCollisionEnter2D(Collision2D other)
    {
        SoundManager.Instance.PlayBrickHit();
        if (GetComponent<SpriteRenderer>().sprite == _damagedSprite)
        {
            _particles = Instantiate(_particles, transform.position, Quaternion.identity);
            _particles.GetComponent<ParticleSystem>().Play();

            if (Random.value > 0.85f)
                SpawnManager.Instance.SpawnBall(transform.position);
            
            Destroy(gameObject);
            return;
        }
        GetComponent<SpriteRenderer>().sprite = _damagedSprite;
    }
}