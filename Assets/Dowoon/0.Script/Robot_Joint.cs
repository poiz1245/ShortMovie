using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Joint : MonoBehaviour
{
    public Robot_Joint m_child;

    public Robot_Joint GetChild()
    {
        return m_child;

    }

    public void Rotate(float _angle)
    {
        transform.Rotate(new Vector3(0,1,0) * _angle);
        

    }
  
}
