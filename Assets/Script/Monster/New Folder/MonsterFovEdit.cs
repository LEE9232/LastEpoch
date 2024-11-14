using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MonsterFov))]
public class MonsterFovEdit : Editor
{

    private void OnSceneGUI()
    {
        //Ŭ���� ���� ����
        MonsterFov fov = (MonsterFov)target;

        //�� ���ǽ����� 1/2����
        Vector3 fromAnglePos = fov.CirclePoint(-fov.viewAngle * 0.5f);

        //�� ����
        // Handles.color = Color.white;

        // �þ߰� �÷�
        Handles.color = new Color(1, 1, 1, 0.1f);


        //�ܰ��� ǥ��
        Handles.DrawWireDisc(fov.transform.position,
            Vector3.up,
            fov.viewRange);

        //��ä�� ���� ����
        Handles.DrawSolidArc(fov.transform.position,
            Vector3.up,
            fromAnglePos,
            fov.viewAngle,
            fov.viewRange);


        Handles.Label(fov.transform.position + (fov.transform.forward * 2.0f),
            fov.viewAngle.ToString());
    }
}
