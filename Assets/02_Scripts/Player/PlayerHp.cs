using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private float _playerHpCount;
    [SerializeField] private float _playerMaxHp = 10;
    [SerializeField] private Image _playerHpImage = null;

    private void Awake()
    {
        _playerHpCount = _playerMaxHp;
        _playerHpImage = GameObject.Find("Canvas/PlayerHpImage").GetComponent<Image>();
    }

    private void Update()
    {
        PlayerDie();
    }

    private void PlayerDie()
    {
        if (_playerHpCount <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BossBullet"))
        {
            _playerHpImage.fillAmount -= 1/_playerMaxHp;
            _playerHpCount--;
            Destroy(collision.gameObject);
        }
    }
}
