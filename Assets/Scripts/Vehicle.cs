using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {
    public Steering[] steerings;
    public float maxSpeed = 10;
    public float maxForce = 100;

    protected float sqrMaxSpeed;

    // 质量
    public float mass = 1;
    // 速度
    public Vector3 velocity;
    // 转向时的速度
    public float damping = 0.9f;
    // 计算间隔
    public float computeInterval = 0.2f;
    // 是否在二维平面，若是，忽略y轴
    public bool isPlanar = true;

    // 操控力
    private Vector3 steeringForce;
    // 加速度
    protected Vector3 acceleration;
    private float timer;

    protected void Start()
    {
        steeringForce = new Vector3(0, 0, 0);
        sqrMaxSpeed = maxSpeed * maxSpeed;
        timer = 0;
        steerings = GetComponents<Steering>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        steeringForce = new Vector3(0, 0, 0);

        if(timer > computeInterval)
        {
            foreach(Steering s in steerings)
            {
                if (s.enabled)
                {
                    steeringForce += s.Force() * s.weight;
                }
            }

            steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
            acceleration = steeringForce / mass;
            timer = 0;
        }
    }
	
}
