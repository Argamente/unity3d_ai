using UnityEngine;
using System.Collections;

/// <summary>
/// 靠近行为
/// </summary>
public class SteeringForSeek : Steering {

    public GameObject target;

    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;
    private bool isPlanar;

    void Start()
    {
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
        isPlanar = m_vehicle.isPlanar;
    }

    public override Vector3 Force()
    {
        // 计算预期速度
        desiredVelocity = (target.transform.position - transform.position).normalized * maxSpeed;
        if (isPlanar)
        {
            desiredVelocity.y = 0;
        }

        // 返回操控向量，预期速度与当前速度的差
        Vector3 result = desiredVelocity - m_vehicle.velocity;
        return result;
    }


}
