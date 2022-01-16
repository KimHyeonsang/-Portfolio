using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiControl : MonoBehaviour
{
    public struct ViewCastInfo
    {
        public bool Hit;
        public Vector3 Point;
        public float Distance;
        public float Angle;

        public ViewCastInfo(bool _Hit, Vector3 _Point, float _Distance, float _Angle)
        {
            Hit = _Hit;
            Point = _Point;
            Distance = _Distance;
            Angle = _Angle;
        }
    }

    [Tooltip("시야 최대 거리")]
    public float Radius;
    [Tooltip("시야 최대 각도")]
    [Range(0, 360)]
    public float Angle;

    [Tooltip("TargetLayerMask")]
    [SerializeField]
    private LayerMask TargetMask;
    [Tooltip("ObstacleMask")]
    [SerializeField]
    private LayerMask ObstacleMask;

   

    [Tooltip("시야각의 라인 갯수")]
    private int LineAngle;


    Mesh ViewMesh;

    private void Start()
    {
        ViewMesh = new Mesh();
        ViewMesh.name = "ViewMesh";

        Radius = 10.0f;
        Angle = 95.0f;
        LineAngle = 1;

    }

    private void Update()
    {
    
        // Collider[] OverlapSphere(Vector3 position, float radius, int layerMask);
        // 자기자신을 중심으로 Radius 거리 만큼 TargetMask들을 다 들고 와라
        Collider[] InTarget = Physics.OverlapSphere(transform.position, Radius, TargetMask);

        for (int i = 0; i < InTarget.Length; ++i)
        {
            // 위치만 받아올려고
            Transform target = InTarget[i].transform;

            // 앞에 있는게 바라보는방향  가는 방향은 같아서 벡터는 동일하다.
            Vector3 TargetDirection = (target.position - transform.position).normalized;

            // 자기자신 부터 타겟거리까지가 지금 주어진값보다 낮을 경우


            // 보이는 시야각안에 있을 경우
            if (Vector3.Angle(transform.forward, TargetDirection) < Angle / 2)
            {
                // 거리
                float TargetDistance = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, TargetDirection, TargetDistance, ObstacleMask))
                {
                    
                }
            }

        }
    }

    private void LateUpdate()
    {
        int LineCount = Mathf.RoundToInt(Angle / LineAngle);

        float AngleSize = Angle / LineCount;

        // ** 버텍스를 담을 리스트
        List<Vector3> ViewPointList = new List<Vector3>();

        //ViewPointList 확인
        for (int i = 0; i < LineCount; ++i)
        {
            float ViewAngle = transform.eulerAngles.y - (Angle / 2) + AngleSize * i;

            ViewCastInfo tViewCast = ViewCast(ViewAngle);

            ViewPointList.Add(tViewCast.Point);
        }

        // ** 모든 버텍스의 개수를 확인  +1을 한 이유는 중앙의점포함할려고
        int VertexCount = ViewPointList.Count + 1;

        // ** 계산상 96개가 만들어짐
        Vector3[] VertexList = new Vector3[VertexCount];
        // ** 자기 자신
        VertexList[0] = Vector3.zero;

        int[] Triangles = new int[(VertexCount - 2) * 3];

        // 모든 라인을 확인하겠다.
        for (int i = 0; i < VertexCount - 1; ++i)
        {
            // ** 로컬 좌표 = InverseTransformPoint(월드 좌표);
            VertexList[i + 1] = transform.InverseTransformPoint(ViewPointList[i]);

            if (i < VertexCount - 2)
            {
                Triangles[i * 3] = 0;
                Triangles[i * 3 + 1] = i + 1;
                Triangles[i * 3 + 2] = i + 2;

            }
        }
        ViewMesh.Clear();
        ViewMesh.vertices = VertexList;
        ViewMesh.triangles = Triangles;

        // ** 삼각형을 그리는 함수
        ViewMesh.RecalculateNormals();

    }

    // 각도 = 180/3.141592  라디안 = 180 * 각도
    public Vector3 LocalViewAngle(float _Angle)
    {
        _Angle += transform.eulerAngles.y;

        return new Vector3(Mathf.Sin(_Angle * Mathf.Deg2Rad),
            0.0f,
            Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }


    public Vector3 DirectionAngle(float _Angle)
    {


        return new Vector3(Mathf.Sin(_Angle * Mathf.Deg2Rad),
            0.0f,
            Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }


    public ViewCastInfo ViewCast(float _Angle)
    {

        Vector3 Direction = DirectionAngle(_Angle);

        RaycastHit Hit;

        if (Physics.Raycast(transform.position, Direction, out Hit, Radius, ObstacleMask))
        {
            return new ViewCastInfo(true, Hit.point, Hit.distance, _Angle);
        }

        return new ViewCastInfo(
            false,
            transform.position + Direction * Radius,
            Radius,
            _Angle);
    }
}
