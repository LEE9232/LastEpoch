using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MonsterFov))]
public class MonsterFovEdit : Editor
{

    private void OnSceneGUI()
    {
        //클래스 참조 선언
        MonsterFov fov = (MonsterFov)target;

        //원 주의시작점 1/2각도
        Vector3 fromAnglePos = fov.CirclePoint(-fov.viewAngle * 0.5f);

        //원 색상
        // Handles.color = Color.white;

        // 시야각 컬러
        Handles.color = new Color(1, 1, 1, 0.1f);


        //외각선 표현
        Handles.DrawWireDisc(fov.transform.position,
            Vector3.up,
            fov.viewRange);

        //부채꼴 색상 지정
        Handles.DrawSolidArc(fov.transform.position,
            Vector3.up,
            fromAnglePos,
            fov.viewAngle,
            fov.viewRange);


        Handles.Label(fov.transform.position + (fov.transform.forward * 2.0f),
            fov.viewAngle.ToString());
    }
}
