using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{

    public string keyPositive;
    public string keyNegative;

    public float targetVelocity;
    public float force;
    
    Rigidbody rb;
    HingeJoint joint;
    JointMotor motor;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joint = GetComponent<HingeJoint>();

        joint.useMotor = true;
        
        // motor.force = 100;
        // motor.targetVelocity = torque;
        // joint.motor = motor;
    }

    // Update is called once per frame
    void Update()
    {

        motor = new JointMotor();
        // joint.motor.force;

        // Vector3 position = this.transform.position;
        // position.x--;
        // this.transform.position = position;


        // KeyCode.LeftArrow
        
        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), keyPositive)))
        {
            motor.force = force;
            motor.targetVelocity = targetVelocity;
        }else if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), keyNegative)))
        {
            motor.force = force;
            motor.targetVelocity = -targetVelocity;
        }
        else
        {
            motor.force = 0;
            motor.targetVelocity = 0;
        }

        joint.motor = motor;

        // float turn = Input.GetAxis("Horizontal");
        // rb.AddTorque(Vector3.forward * torque * turn);

        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     // Vector3 position = this.transform.position;
        //     // position.x--;
        //     // this.transform.position = position;
        // }

    }
}
