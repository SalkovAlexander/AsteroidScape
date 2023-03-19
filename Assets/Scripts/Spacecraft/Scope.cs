using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    private GameObject objectToPlace;
    [SerializeField] private GameObject Prefab = null;
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private LayerMask ignoreLayer;

    private void Start()
    {
        objectToPlace = Instantiate(Prefab, Vector3.zero, Quaternion.Euler(Vector3.zero));
        objectToPlace.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(transform.position + transform.forward * 5, transform.forward);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, raycastDistance,~ignoreLayer))
        {
            objectToPlace.SetActive(true);
            objectToPlace.transform.position = hitInfo.point;
            objectToPlace.transform.rotation = transform.rotation;
        }
        else
        {
            objectToPlace.SetActive(false);
        }
    }
}
