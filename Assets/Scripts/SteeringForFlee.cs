using UnityEngine;
using System.Collections;

/// <summary>
/// 离开行为
/// </summary>
public class SteeringForFlee : Steering {
    public GameObject target;
    public float fearDistance = 20;
    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;

    void Start()
    {
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
    }

    public override Vector3 Force()
    {
        Vector3 tmpPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 tmpTargetPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);

        if(Vector3.Distance(tmpPos,tmpTargetPos) > fearDistance)
        {
            return new Vector3(0, 0, 0);
        }

        desiredVelocity = (transform.position - target.transform.position).normalized * maxSpeed;
        Vector3 result = desiredVelocity - m_vehicle.velocity;
        return result;
    }
}
