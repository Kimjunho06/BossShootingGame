using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WGoToPattern : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bullet;

    [SerializeField] private bool _isGoToBlack = false;

    public bool GoToBlackPatternDelay = false;

    QCirclePattern QPattern;

    private void Awake()
    {
        QPattern = GetComponent<QCirclePattern>();
    }

    private void Start()
    {
        StartCoroutine("GoToDelay");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _isGoToBlack == false 
            && QPattern.CircleBlackPatternDelay == false
            && GoToBlackPatternDelay == false)
        {
            shot();
            _isGoToBlack = true;
            QPattern.CircleBlackPatternDelay = true;
            GoToBlackPatternDelay = true;
        }
    }

    void shot()
    {
        //Target�������� �߻�� ������Ʈ ����
        var bl = new List<Transform>();

        for (int i = 0; i < 360; i++)
        {
            //�Ѿ� ����
            var temp = PoolManager.Instance.Pop(bullet);

            //�Ѿ� ���� ��ġ 
            temp.transform.position = transform.position;

            //?���Ŀ� Target���� ���ư� ������Ʈ ����
            bl.Add(temp.transform);

            //Z�� ���� ���ؾ� ȸ���� �̷�����Ƿ�, Z�� i�� �����Ѵ�.
            temp.transform.rotation = Quaternion.Euler(1, 0, i);
        }
        //�Ѿ��� Target �������� �̵���Ų��.
        StartCoroutine(BulletToTarget(bl));
    }

    IEnumerator BulletToTarget(List<Transform> bl)
    {
        //0.5�� �Ŀ� ����
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < bl.Count; i++)
        {
            //���� �Ѿ��� ��ġ���� �÷����� ��ġ�� ���Ͱ��� �y���Ͽ� ������ ����
            var target_dir = bl[i].position - target.transform.position ;

            //x,y�� ���� �����Ͽ� Z���� ������ ������. -> ~�� ������ ����
            var angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;

            //Target �������� �̵�
            bl[i].rotation = Quaternion.Euler(0, 0, angle);
        }

        //������ ����
        bl.Clear();
    }

    IEnumerator GoToDelay()
    {
        while (true)
        {
            if (_isGoToBlack == true)
            {
                yield return new WaitForSeconds(1f);
                _isGoToBlack = false;
                yield return new WaitForSeconds(1f);
                GoToBlackPatternDelay = false;
                QPattern.CircleBlackPatternDelay = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
