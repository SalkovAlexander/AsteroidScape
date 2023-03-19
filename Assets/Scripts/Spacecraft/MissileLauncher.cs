using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MissileLauncher : MonoBehaviour
{
    private Spacecraft MissileLaunch = null;
    [SerializeField] private GameObject prefab; // The prefab to spawn
    [SerializeField] private float force = 100f; // The force to add to the spawned prefab
    [SerializeField] private float SpawnOffset = 5f;
    [SerializeField] public Transform MissileTarget = null;



    private void OnEnable() {
        MissileLaunch.Enable();
        MissileLaunch.Player.Fire.performed += Launch;
    }

    private void OnDisable() {
        MissileLaunch.Disable();
        MissileLaunch.Player.Fire.performed -= Launch;
    }

    void Awake(){
        MissileLaunch = new Spacecraft();
    }

    public void Launch(InputAction.CallbackContext Value)
    {
        GameObject newObject = Instantiate(prefab, transform.position + transform.forward * SpawnOffset, transform.rotation); // Spawn the prefab at the position of the game object
        Rigidbody rb = newObject.GetComponent<Rigidbody>(); // Get the Rigidbody component of the spawned prefab
        rb.AddForce(transform.forward.normalized * force, ForceMode.Impulse); // Apply the specified force in the forward direction of the game object

        if(MissileTarget != null)
        {
            newObject.GetComponent<AutoaimMissile>().target = MissileTarget;
        }
    }
}
