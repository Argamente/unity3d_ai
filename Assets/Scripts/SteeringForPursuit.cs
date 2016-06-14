using UnityEngine;
using System.Collections;

/// <summary>
/// 追逐行为
/// </summary>
public class SteeringForPursuit : Steering {
    public GameObject target;
    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;

    private Vehicle target_vehicle;

    void Start()
    {
        m_vehicle = GetComponent<Vehicle>();
        target_vehicle = target.GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
    }

    public override Vector3 Force()
    {
        Vector3 toTarget = target.transform.position - transform.position;
        float relativeDirection = Vector3.Dot(transform.forward, target.transform.forward);

        Vector3 result;

        // 基本面对着目标
        if ((Vector3.Dot(toTarget,transform.forward) > 0) && (relativeDirection < -0.95f))
        {
            desiredVelocity = (target.transform.position - transform.position).normalized * maxSpeed;
            result = desiredVelocity - m_vehicle.velocity;
            return result;
        }

        // 
        float lookaheadTime = toTarget.magnitude / (maxSpeed + target_vehicle.velocity.magnitude);
        desiredVelocity = (target.transform.position + target_vehicle.velocity * lookaheadTime - transform.position).normalized * maxSpeed;
        result = desiredVelocity - m_vehicle.velocity;
        return result;
    }


}
