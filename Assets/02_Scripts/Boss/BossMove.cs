using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [Header("���� �̵� ����")]
    [SerializeField] private float _MaxPortableX;
    [SerializeField] private float _MinPortableX;

    [SerializeField] private float _MoveSpeed = 6f;
    [SerializeField] private float _MoveLength = 3f;

    [SerializeField] private float _MoveDelayTime;
    
    public float time;

    private void Update()
    {
        LimitMove();
    }

    private void Start()
    {
        
    }

    

    private void LimitMove()
    {
        time = Mathf.Sin(Time.time * _MoveSpeed);
        transform.position = new Vector2(transform.position.x, time * _MoveLength);
    }
}
