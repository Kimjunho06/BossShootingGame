using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHp : MonoBehaviour
{
    [SerializeField] private Image _hpImage = null;
    [SerializeField] private float _hpScale = 100;

    private void Awake()
    {
        _hpImage = GameObject.Find("Canvas/HpImage").GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _hpImage.fillAmount -= 0.01f;
        _hpScale--;
        Destroy(collision.gameObject);

    }


}
