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

    [SerializeField] bool _isChangecolor = false;

    [SerializeField] SpriteRenderer _currentBulletImage;


    BossPattern _bossPattern;

    private void Awake()
    {
        _currentBulletImage = GameObject.Find("CurrentBulletImage").GetComponent<SpriteRenderer>();

        _bossPattern =GameObject.Find("Boss_Player").GetComponent<BossPattern>();
        _playerHpCount = _playerMaxHp;
        _playerHpImage = GameObject.Find("Canvas/PlayerHpImage").GetComponent<Image>();
    }

    private void Update()
    {
        PlayerDie();
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isChangecolor = true;
            _currentBulletImage.sprite = _bossPattern._spriteRenderer_white.sprite;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isChangecolor = false;
            _currentBulletImage.sprite = _bossPattern._spriteRenderer_black.sprite;
        }
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
        if(_isChangecolor == false)
        {
            if (collision.gameObject.CompareTag("BossBullet"))
            {
                _playerHpImage.fillAmount -= 1/_playerMaxHp;
                _playerHpCount--;
                PoolManager.Instance.Push(collision.gameObject);
            }
        }
        else if (_isChangecolor == true)
        {
            if (collision.gameObject.CompareTag("BossBulletWhite"))
            {
                _playerHpImage.fillAmount -= 1 / _playerMaxHp;
                _playerHpCount--;
                PoolManager.Instance.Push(collision.gameObject);
            }
        }
    }
}
