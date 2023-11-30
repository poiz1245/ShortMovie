using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour

{
    // 시작점
    public Robot_Joint m_root;

    // 끝점
    public Robot_Joint m_end;

    // 목표점
    [Header(" 로봇 팔은 타겟으로 지정된 게임오브젝트의 좌표를 따라감")]
    public GameObject m_target;

    public float m_rate = 5;
    public float m_steps = 20;

    public float m_threshold = 0.05f;
    float CalculateSlope(Robot_Joint _joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(m_end.transform.position,m_target.transform.position);

        _joint.Rotate(deltaTheta);
   
       // _joint.Rotate(deltaTheta);
       float distance2 = GetDistance(m_end.transform.position, m_target.transform.position);

        _joint.Rotate(-deltaTheta);


        return (distance2 - distance1) / deltaTheta;
    }
    private void Update()
    {

        for(int i=0; i< m_steps; ++i)
        {
            if (GetDistance(m_end.transform.position, m_target.transform.position) > m_threshold)
            {
                Robot_Joint current = m_root;
                while (current != null)
                {
                    float slope = CalculateSlope(current);
                    current.Rotate(-slope * m_rate);
                    current = current.GetChild();

                }

            }
        }
       
     
        
    }
    float GetDistance(Vector3 _point1, Vector3 _point2)
    {
        return Vector3.Distance(_point1, _point2);
    }


   

}
