using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HelpButton : MonoBehaviour
{
    [SerializeField] private RectTransform _helpRectTrm;

    private void Awake()
    {
        _helpRectTrm = GetComponent<RectTransform>();
    }

    public void CloseHelp()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_helpRectTrm.DOAnchorPos(Vector2.zero + new Vector2(0, 1200f), 0.3f));
    }

    public void OpenHelp()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_helpRectTrm.DOAnchorPos(Vector2.zero - new Vector2(0, 70f), 0.3f));
        seq.Append(_helpRectTrm.DOAnchorPos(Vector2.zero + new Vector2(0, 30f), 0.2f));
        seq.Append(_helpRectTrm.DOAnchorPos(Vector2.zero, 0.2f));
    }
}
