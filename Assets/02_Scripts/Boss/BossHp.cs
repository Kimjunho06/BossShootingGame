using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BossHp : MonoBehaviour
{
    [SerializeField] private Image _hpImage = null;
    [SerializeField] private float _hpCount;
    [SerializeField] private float _maxHp = 10;

    private void Awake()
    {
        _hpCount = _maxHp;
        _hpImage = GameObject.Find("Canvas/BossHpImage").GetComponent<Image>();
    }

    private void Update()
    {
        BossDie();
    }

    private void BossDie()
    {
        if (_hpCount <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _hpImage.fillAmount -= 1/_hpCount;
            _hpCount--;
            Destroy(collision.gameObject);
        }
    }


}
