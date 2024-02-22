using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Sprite _damagedSprite;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (GetComponent<SpriteRenderer>().sprite == _damagedSprite && other.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            GetComponent<SpriteRenderer>().sprite = _damagedSprite;
        }
    }
}
