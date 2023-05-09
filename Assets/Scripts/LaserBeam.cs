using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField] private float maxDistance = 50f;
    [SerializeField] private float DamagePerSeconf = 5f;
    [SerializeField] private bool isDamager = true;
    [SerializeField] private string damageTag = "Player"; 
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if(hit.rigidbody.gameObject.CompareTag(damageTag) && isDamager)
            {
                Debug.Log("HIT");
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
                hit.rigidbody.gameObject.GetComponent<HDSystem>().TakeDamage(DamagePerSeconf*Time.deltaTime);
            }
            else
            {
                Debug.Log("HIT BUUUT");
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position);
            }
        }
        else
        {
            Debug.Log("NO HIT");
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
        }

    }
}