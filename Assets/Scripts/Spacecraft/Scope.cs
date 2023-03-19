using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    private GameObject objectToPlace;
    [SerializeField] private GameObject Prefab = null;
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private LayerMask ignoreLayer;
    [SerializeField] private Transform MissleTarget = null;

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

            //Adding target
            if (Input.GetMouseButtonDown(1))
            {
                if(MissleTarget != null)
                    MissleTarget.gameObject.layer = 1;
                Debug.Log("Target changed");
                MissleTarget = hitInfo.transform;
                gameObject.GetComponent<MissileLauncher>().MissileTarget = MissleTarget;
                MissleTarget.gameObject.layer = 7;
            }
        }
        else
        {
            objectToPlace.SetActive(false);
            if (Input.GetMouseButtonDown(1))
            {
                if(MissleTarget != null)
                    MissleTarget.gameObject.layer = 1;
                MissleTarget = null;
                gameObject.GetComponent<MissileLauncher>().MissileTarget = MissleTarget;
            }
        }
    }
}
