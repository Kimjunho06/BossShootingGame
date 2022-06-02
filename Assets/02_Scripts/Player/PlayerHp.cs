using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private int _playerHp = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerHp--;
        Destroy(collision.gameObject);
    }
}
