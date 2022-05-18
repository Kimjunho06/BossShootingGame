using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f; // ¾ÆÁ÷ ¾È ¾¸
    [SerializeField] private float _moveTrmDelaySecond;

    private Sequence _moveSequence;
    
    private float _randomTransX;
    private float _randomTransY;


    private void Update()
    {
        Move();
    }

    private void Start()
    {
        StartCoroutine("MoveTransDelay");
    }

    
    IEnumerator MoveTransDelay()
    {
        _randomTransX = Random.Range(-8.5f, 0f);
        _randomTransY = Random.Range(-3f, 3.8f);
        _moveTrmDelaySecond = Random.Range(1f, 2f);
        yield return new WaitForSecondsRealtime(_moveTrmDelaySecond);
        StartCoroutine("MoveTransDelay");
    }

    private void Move()
    {
        _moveSequence = DOTween.Sequence().SetAutoKill(false)
            .Append(transform.DOMove(new Vector3(_randomTransX, _randomTransY, 0), 0.5f)).SetEase(Ease.InOutSine);
    }
}
