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
        //Target방향으로 발사될 오브젝트 수록
        var bl = new List<Transform>();

        for (int i = 0; i < 360; i++)
        {
            //총알 생성
            var temp = PoolManager.Instance.Pop(bullet);

            //총알 생성 위치 
            temp.transform.position = transform.position;

            //?초후에 Target에게 날아갈 오브젝트 수록
            bl.Add(temp.transform);

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(1, 0, i);
        }
        //총알을 Target 방향으로 이동시킨다.
        StartCoroutine(BulletToTarget(bl));
    }

    IEnumerator BulletToTarget(List<Transform> bl)
    {
        //0.5초 후에 시작
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < bl.Count; i++)
        {
            //현재 총알의 위치에서 플레이의 위치의 벡터값을 뻴셈하여 방향을 구함
            var target_dir = bl[i].position - target.transform.position ;

            //x,y의 값을 조합하여 Z방향 값으로 변형함. -> ~도 단위로 변형
            var angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;

            //Target 방향으로 이동
            bl[i].rotation = Quaternion.Euler(0, 0, angle);
        }

        //데이터 해제
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
