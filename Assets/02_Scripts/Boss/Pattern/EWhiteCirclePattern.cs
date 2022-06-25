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
        //360�� �ݺ�
        for (int i = 0; i < 360; i++)
        {
            //�Ѿ� ����
            GameObject temp = PoolManager.Instance.Pop(bullet);

            temp.transform.position = transform.position;

            //Z�� ���� ���ؾ� ȸ���� �̷�����Ƿ�, Z�� i�� �����Ѵ�.
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
