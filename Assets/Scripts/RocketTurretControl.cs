using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RocketTurretControl : TurretController
{
    [SerializeField] private float callInterval = 10f;
    private float timer = 0f;

    private void Start() 
    {
        base.Start();  
    }

    void Update()
    {
        base.Update();

        timer += Time.deltaTime;
        if (timer >= callInterval && distanceToTarget <= attackDistance)
        {
            this.gameObject.GetComponentInChildren<MissileLauncher>().MissileTarget = target;
            this.gameObject.GetComponentInChildren<MissileLauncher>().Launch();
            timer = 0f;
        }
    }
}

[CustomEditor(typeof(RocketTurretControl))]
public class HandlesEditor_two : HandlesEditor_one
{
    void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}