using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RocketTurretControl : TurretController
{
    [SerializeField] private float callInterval = 10f; // the time interval between function calls
    
    private float timer = 0f; // a timer to keep track of the time elapsed

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
public class HandlesEditor_one : Editor
{
    SerializedProperty attackDistance;

    void OnEnable()
    {
        attackDistance = serializedObject.FindProperty("attackDistance");
    }
    public void OnSceneGUI()
    {
        var linkedObject = target as RocketTurretControl;
        EditorGUI.BeginChangeCheck();

        Handles.color = Color.red;
        float newAttackDistance = Handles.RadiusHandle(Quaternion.identity, linkedObject.transform.position, attackDistance.floatValue, false);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Update params");
            attackDistance.floatValue = newAttackDistance;
            serializedObject.ApplyModifiedProperties();
        }
    }
}