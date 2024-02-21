using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _paddlePrefab;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _brickPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        _paddlePrefab.SetActive(true);
        _ballPrefab.SetActive(true);
        _brickPrefab.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
