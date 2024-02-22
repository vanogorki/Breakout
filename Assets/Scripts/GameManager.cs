using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _paddlePrefab;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _brickPrefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        // spawn paddle
        Instantiate(_paddlePrefab, new Vector3(0, -4f, 0), Quaternion.identity);
        // spawn ball
        Instantiate(_ballPrefab, new Vector3(0, -3.9f, 0), Quaternion.identity);
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
        
    }
}
