using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private float scrollRange; // 앞에거 빼기 뒤에거
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
