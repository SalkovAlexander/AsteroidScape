using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform baseBone;
    [SerializeField] private Transform yHingeBone;
    [SerializeField] private Transform xHingeBone;
    [SerializeField] private Transform aimPoint;
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float maxRotationAngle = 10f;
    private Quaternion baseRotationOffset;
    private Quaternion yHingeRotationOffset;
    private Quaternion xHingeRotationOffset;

    private void Start()
    {
        baseRotationOffset = baseBone.localRotation;
        yHingeRotationOffset = yHingeBone.localRotation;
        xHingeRotationOffset = xHingeBone.localRotation;
    }

    private void Update()
    {
        Vector3 targetDirection = target.position - aimPoint.position;
        Quaternion turretRotation = Quaternion.Euler(transform.eulerAngles);
        Quaternion targetRotation = Quaternion.Inverse(turretRotation) * Quaternion.LookRotation(targetDirection);

        Quaternion yHingeRotation = Quaternion.Euler(0f, 0f, targetRotation.eulerAngles.y);
        Quaternion xHingeRotation = Quaternion.Euler(targetRotation.eulerAngles.x * -1, 0f, 0f);

        float dot = Vector3.Dot(targetDirection.normalized, transform.forward);
        if (Mathf.Acos(dot) * Mathf.Rad2Deg < maxRotationAngle)
        {
            if(rotationSpeed == 0)
            {
	            baseBone.localRotation = baseRotationOffset;
                yHingeBone.localRotation = yHingeRotationOffset * yHingeRotation;
                xHingeBone.localRotation = xHingeRotationOffset * xHingeRotation;
            }
            else
            {
                baseBone.localRotation = baseRotationOffset;
                yHingeBone.localRotation = Quaternion.RotateTowards(yHingeBone.localRotation, yHingeRotationOffset * yHingeRotation, rotationSpeed * Time.deltaTime);
                xHingeBone.localRotation = Quaternion.RotateTowards(xHingeBone.localRotation, xHingeRotationOffset * xHingeRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}