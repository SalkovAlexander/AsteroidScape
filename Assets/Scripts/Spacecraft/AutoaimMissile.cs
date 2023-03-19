using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoaimMissile : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float turnSpeed = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the direction towards the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Calculate the angle between the missile's forward vector and the target direction
            float angle = Vector3.Angle(transform.forward, direction);

            // Rotate the missile towards the target direction
            Vector3 rotation = Vector3.RotateTowards(transform.forward, direction, turnSpeed * Time.deltaTime, 0f);
            rb.MoveRotation(Quaternion.LookRotation(rotation));

            // Move the missile forwards towards the target
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
    }
}
