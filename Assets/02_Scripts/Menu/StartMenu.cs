using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTrm;

    private void Awake()
    {
        _rectTrm = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectModeOpen();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SelectModeClose();
        }
    }

    private void SelectModeClose()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_rectTrm.DOAnchorPos(Vector2.zero + new Vector2(0, 1200f), 0.3f));
    }

    public void SelectModeOpen()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_rectTrm.DOAnchorPos(Vector2.zero - new Vector2(0, 70f), 0.3f));
        seq.Append(_rectTrm.DOAnchorPos(Vector2.zero + new Vector2(0, 30f), 0.2f));
        seq.Append(_rectTrm.DOAnchorPos(Vector2.zero, 0.2f));
    }
}
