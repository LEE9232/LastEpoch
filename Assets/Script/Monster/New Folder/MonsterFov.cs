using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 몬스터 시야각 스크립트

public class MonsterFov : MonoBehaviour
{

    public float viewRange = 15.0f;
    // 적 시야 거리

    public float viewAngle = 360.0f;
    // 적 시야각 


    private Transform Monstertranform;
    private Transform Playertranform;
    private int playerLayer;
    private int obstacleLayer;
    private int layerMask;

    void Start()
    {
        //컴포넌트 추출 
        Monstertranform = GetComponent<Transform>();
        Playertranform = GameObject.FindGameObjectWithTag("PLAYER").transform;

        // 레이어 마스크값 
        playerLayer = LayerMask.NameToLayer("PLAYER");
        obstacleLayer = LayerMask.NameToLayer("OBSTACLE");
        layerMask = 1 << playerLayer | 1 << obstacleLayer;
        

    }

    // 각도의 의한 주위 점의 좌표값을 계산함수
    public Vector3 CirclePoint(float angle)
    {
        // 로컬 좌표계기준으로 몬스터에게 y회전값 줌
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),
            0,
            Mathf.Cos(angle * Mathf.Deg2Rad));
    
    }

    public bool isTracePlayer()
    {
        bool isTrace = false;

        // 추척 반경 범위에서 플레이서 추출
        Collider[] colls = Physics.OverlapSphere(Monstertranform.position,
            viewRange,
            1 << playerLayer);

        // 배열 개수가 1일때 플레이어가 범위값안에 있다고 판단
        if (colls.Length == 1)
        {
            //몬스터와 플레이어 사이야 방향 벡터 계산
            Vector3 dir = (Playertranform.position - Monstertranform.position).normalized;

            //몬스터의 시야각 들어잇는지 판단
            if(Vector3.Angle(Monstertranform.forward, dir)< viewAngle * 0.5f)
            {
                isTrace = true;
            }

        }
        return isTrace;

    }

    public bool isViewPlayer()
    {
        bool isView = false;
        RaycastHit hit;

        // 방향 벡터
        Vector3 dir = (Playertranform.position - Monstertranform.position).normalized;

        // 레이 캐스트로 장애물 여부 판단
        if(Physics.Raycast(Monstertranform.position, dir, out hit, viewRange, layerMask))
        {
            isView = (hit.collider.CompareTag("PLAYER"));
        }
        return isView;
    }

}
