using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    
    [SerializeField] private GameObject _paddle;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject[] _bricks;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    public void SpawnBall(Vector3 position)
    {
        Instantiate(_ball, position, Quaternion.identity);
    }
    
    public void SpawnRandomBrick(Vector3 position)
    {
        var randomIndex = Random.Range(0, _bricks.Length);
        Instantiate(_bricks[randomIndex], position, Quaternion.identity);
    }
    
    public void SpawnPaddle()
    {
        Instantiate(_paddle, new Vector3(0, -4f, 0), Quaternion.identity);
    }
}
