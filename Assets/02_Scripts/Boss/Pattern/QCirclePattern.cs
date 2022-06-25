using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QCirclePattern : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private bool _isCircleBlack = false;

    public bool CircleBlackPatternDelay = false;

    WGoToPattern WPattern;


    private void Awake()
    {
        WPattern = GetComponent<WGoToPattern>();    
    }

    private void Start()
    {
        StartCoroutine("CircleDelay");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _isCircleBlack == false
            && CircleBlackPatternDelay == false
            && WPattern.GoToBlackPatternDelay == false)
        {
            shot();
            _isCircleBlack = true;

            CircleBlackPatternDelay = true;
            WPattern.GoToBlackPatternDelay = true;
        }
    }

    void shot()
    {
        //360번 반복
        for (int i = 0; i < 360; i++)
        {
            //총알 생성
            GameObject temp = PoolManager.Instance.Pop(bullet);

            temp.transform.position = transform.position;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    IEnumerator CircleDelay()
    {
        while (true)
        {
            if (_isCircleBlack == true)
            {
                yield return new WaitForSeconds(1f);
                _isCircleBlack = false;
                yield return new WaitForSeconds(1f);
                CircleBlackPatternDelay = false;
                WPattern.GoToBlackPatternDelay = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

}
