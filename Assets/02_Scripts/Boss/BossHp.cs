using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BossHp : MonoBehaviour
{
    [SerializeField] private Image _hpImage = null;
    [SerializeField] private float _hpCount = 100;

    private void Awake()
    {
        _hpImage = GameObject.Find("Canvas/HpImage").GetComponent<Image>();
    }

    private void Update()
    {
        BossDie();
    }

    private void BossDie()
    {
        if (_hpCount == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _hpImage.fillAmount -= 1/(_hpCount+1);// 1/ÇÇ
        _hpCount--;
        Destroy(collision.gameObject);

    }


}
