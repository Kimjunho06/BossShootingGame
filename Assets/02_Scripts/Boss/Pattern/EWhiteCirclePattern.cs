using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EWhiteCirclePattern : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private bool _isCircleWhite = false;

    public bool CircleWhitePatternDelay = false;

    RWhiteGoToPattern RPattern;


    private void Awake()
    {
        RPattern = GetComponent<RWhiteGoToPattern>();
    }

    private void Start()
    {
        StartCoroutine("CircleDelay");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isCircleWhite == false
            && CircleWhitePatternDelay == false
            && RPattern.GoToWhitePatternDelay == false)
        {
            shot();
            _isCircleWhite = true;

            CircleWhitePatternDelay = true;
            RPattern.GoToWhitePatternDelay = true;
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
            if (_isCircleWhite == true)
            {
                yield return new WaitForSeconds(1f);
                _isCircleWhite = false;
                yield return new WaitForSeconds(1f);
                CircleWhitePatternDelay = false;
                RPattern.GoToWhitePatternDelay = false;
            }
            yield return new WaitForSeconds(0.11f);
        }
    }
}
