using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; // ¾ÆÁ÷ ¾È ¾¸
    [SerializeField] private float _moveTrmDelaySecond = 2f;

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
        _randomTransX = Random.Range(-8.5f, 2f);
        _randomTransY = Random.Range(-5f, 4.5f);
        yield return new WaitForSecondsRealtime(_moveTrmDelaySecond);
        StartCoroutine("MoveTransDelay");
    }

    private void Move()
    {
        transform.position = new Vector3(_randomTransX, _randomTransY);     
    }
}
