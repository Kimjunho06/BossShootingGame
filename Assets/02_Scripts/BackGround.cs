using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private float scrollRange; // �տ��� ���� �ڿ���
    [SerializeField] Transform target;
    private void Start()
    {

    }
    private void Update()
    {
        ReBackground();
    }

    private void ReBackground()
    {
        if (transform.position.x <= -scrollRange)
        {
            transform.position = target.position + Vector3.right * scrollRange;
        }
    }
}
