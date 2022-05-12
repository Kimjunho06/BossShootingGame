using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [Header("보스 이동 제한")]
    [SerializeField] private float _MaxPortableX;
    [SerializeField] private float _MinPortableX;

    [SerializeField] private float _MoveSpeed = 6f;
    [SerializeField] private float _MoveLength = 3f;
    public float time;

    private void Start()
    {
        
    }
    private void Update()
    {
        LimitMove();
    }

    private void LimitMove()
    {
        time = Mathf.Sin(Time.time * _MoveSpeed);
        transform.position = new Vector2(transform.position.x, time * _MoveLength);

    }
}
