using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    [Header("�̵� ���� ����")]
    [SerializeField] private float _MoveSpeed;
    [SerializeField] Vector3 Movedirection = Vector3.zero;


    private void Update()
    {
        transform.position += Movedirection * _MoveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        Movedirection = direction;
    }
}
