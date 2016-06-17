using UnityEngine;
using System.Collections;

// 逃避
public class SteeringForEvade : Steering {
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
        float lookaheadTime = toTarget.magnitude / (maxSpeed + target_vehicle.velocity.magnitude);
        desiredVelocity = (transform.position - (target.transform.position + target_vehicle.velocity * lookaheadTime)).normalized * maxSpeed;
        Vector3 result = desiredVelocity - m_vehicle.velocity;
        return result;
    }

}
