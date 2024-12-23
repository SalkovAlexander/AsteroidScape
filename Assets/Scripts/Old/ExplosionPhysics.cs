using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPhysics : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 10.0f;
    public float upwardsModifier = 3.0f;

    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, upwardsModifier, ForceMode.Impulse);
            }
        }
    }
}
