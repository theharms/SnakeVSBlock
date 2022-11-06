using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float Speed;
    public Rigidbody Rigidbody;
    private Vector3 _previousMousePosition;
    public float Sensitivity;

    void Update()
    {
        Rigidbody.velocity = Vector3.forward * Speed;

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Rigidbody.velocity = new Vector3(delta.x * Sensitivity, 0.0f, Speed);
        }

        _previousMousePosition = Input.mousePosition;
    }
}
