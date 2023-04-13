using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Programmer: Holly

public class PlayerController : MonoBehaviour
{
    private int timesCollided = 0;

    [Header("Speed")]
    [SerializeField] private float force = 10;
    [SerializeField] private float drag = 0.5f;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float angularDrag = 0.5f;
    
    private Vector3 inputDir = Vector3.zero;
    private Vector3 forceDir;
    private Vector3 rotation = Vector3.zero;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Obstacle")
        {
            timesCollided++;
            if (timesCollided > 1)
            {
                Debug.Log("You collided with an obstacle " + timesCollided + " times.");
            }
            else 
            {
                Debug.Log("You collided with an obstacle " + timesCollided + " time.");
            }
        }    
    }

    void FixedUpdate()
    {
        rb.drag = drag;
        rb.angularDrag = angularDrag;
        inputDir.z = Input.GetAxisRaw("Vertical");
        rotation.y = Input.GetAxisRaw("Horizontal");
        forceDir = Quaternion.Euler(rotation) * inputDir;
        rb.AddRelativeForce(force * forceDir);
        rb.AddRelativeTorque(rotation * rotationSpeed);
    }
}
