using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Spacecraft_controls : MonoBehaviour
{
    [SerializeField] private float OrientationSpeed = 200;
    [SerializeField] private float ThrusterSpeed = 400;
    private Rigidbody rb;
    private Spacecraft Movement = null;
    private float Thrust = 0;

    private void OnEnable() {
        Movement.Enable();
    }
    private void OnDisable() {
        Movement.Disable();
    }

    void Awake(){
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        rb = this.GetComponent<Rigidbody>();
        Movement = new Spacecraft();
    }

    private void SpeedControl(InputAction.CallbackContext Value)
    {
        Thrust+= Value.ReadValue<float>();
    }

    void Update(){
        
    }

    private void FixedUpdate() {
        rb.AddRelativeForce(new Vector3(0, 0,Mathf.Clamp(Movement.Player.ThrustRoll.ReadValue<Vector2>().y, 0, 1))*ThrusterSpeed);
        rb.AddRelativeTorque(new Vector3(Movement.Player.Orientation.ReadValue<Vector2>().y*-1, Movement.Player.Orientation.ReadValue<Vector2>().x, Movement.Player.ThrustRoll.ReadValue<Vector2>().x*-1)*OrientationSpeed);
    }
}