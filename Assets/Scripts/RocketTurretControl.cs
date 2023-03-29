using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTurretControl : MonoBehaviour
{
    public float callInterval = 10f; // the time interval between function calls
    private float timer = 0f; // a timer to keep track of the time elapsed


    void Update()
    {
        // increase the timer by the time elapsed since the last frame
        timer += Time.deltaTime;

        // check if the timer has exceeded the call interval
        if (timer >= callInterval)
        {
            // call the function
            this.gameObject.GetComponent<MissileLauncher>().Launch();

            // reset the timer
            timer = 0f;
        }
    }
}
