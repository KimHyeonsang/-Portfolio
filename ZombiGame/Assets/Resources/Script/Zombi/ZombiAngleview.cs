using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Zombiview))]
public class ZombiAngleview : Editor
{
    private void OnSceneGUI()
    {
        Zombiview t = (Zombiview)target;

        // 원그리기
        Handles.DrawWireArc
            (t.transform.position, Vector3.up, Vector3.forward, 360.0f,t.Radius);

        // 좌측 시야각 최대치
        Vector3 LeftViewAngle = t.LocalViewAngle(-t.Angle / 2.0f);
        // 우측 시야각 최대치
        Vector3 RightViewAngle = t.LocalViewAngle(t.Angle / 2.0f);

        Handles.DrawLine(t.transform.position, t.transform.position + LeftViewAngle * t.Angle);
        Handles.DrawLine(t.transform.position, t.transform.position + RightViewAngle * t.Angle);

        Handles.color = Color.green;

        for(int i=0;i<t.TargetList.Count;++i)
            Handles.DrawLine(t.transform.position, t.TargetList[i].position);
    }
}
