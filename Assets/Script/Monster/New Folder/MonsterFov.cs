using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���� �þ߰� ��ũ��Ʈ

public class MonsterFov : MonoBehaviour
{

    public float viewRange = 15.0f;
    // �� �þ� �Ÿ�

    public float viewAngle = 360.0f;
    // �� �þ߰� 


    private Transform Monstertranform;
    private Transform Playertranform;
    private int playerLayer;
    private int obstacleLayer;
    private int layerMask;

    void Start()
    {
        //������Ʈ ���� 
        Monstertranform = GetComponent<Transform>();
        Playertranform = GameObject.FindGameObjectWithTag("PLAYER").transform;

        // ���̾� ����ũ�� 
        playerLayer = LayerMask.NameToLayer("PLAYER");
        obstacleLayer = LayerMask.NameToLayer("OBSTACLE");
        layerMask = 1 << playerLayer | 1 << obstacleLayer;
        

    }

    // ������ ���� ���� ���� ��ǥ���� ����Լ�
    public Vector3 CirclePoint(float angle)
    {
        // ���� ��ǥ��������� ���Ϳ��� yȸ���� ��
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),
            0,
            Mathf.Cos(angle * Mathf.Deg2Rad));
    
    }

    public bool isTracePlayer()
    {
        bool isTrace = false;

        // ��ô �ݰ� �������� �÷��̼� ����
        Collider[] colls = Physics.OverlapSphere(Monstertranform.position,
            viewRange,
            1 << playerLayer);

        // �迭 ������ 1�϶� �÷��̾ �������ȿ� �ִٰ� �Ǵ�
        if (colls.Length == 1)
        {
            //���Ϳ� �÷��̾� ���̾� ���� ���� ���
            Vector3 dir = (Playertranform.position - Monstertranform.position).normalized;

            //������ �þ߰� ����մ��� �Ǵ�
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

        // ���� ����
        Vector3 dir = (Playertranform.position - Monstertranform.position).normalized;

        // ���� ĳ��Ʈ�� ��ֹ� ���� �Ǵ�
        if(Physics.Raycast(Monstertranform.position, dir, out hit, viewRange, layerMask))
        {
            isView = (hit.collider.CompareTag("PLAYER"));
        }
        return isView;
    }

}
