using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BossHp : MonoBehaviour
{
    [SerializeField] private Image _bossHpImage = null;
    [SerializeField] private float _bossHpCount;
    [SerializeField] private float _bossMaxHp = 10;

    public GameObject _bullet;

    private void Awake()
    {
        _bossHpCount = _bossMaxHp;
        _bossHpImage = GameObject.Find("Canvas/BossHpImage").GetComponent<Image>();
    }

    private void Update()
    {
        BossDie();
    }

    private void BossDie()
    {
        if (_bossHpCount <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _bossHpImage.fillAmount -= 1/_bossMaxHp;
            _bossHpCount--;
            PoolManager.Instance.Push(collision.gameObject);
        }
    }


}
