using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    //[SerializeField] public static bool isMin = false;
    public float myTimeScale = 1.0f;
    public GameObject target;
    public float launchForce = 10f;

    Rigidbody rb;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Time.timeScale = myTimeScale;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FiringSolution firing = new FiringSolution();
            Nullable<Vector3> aimVector = firing.Calculate(transform.position, target.transform.position, launchForce, Physics.gravity);
            if(aimVector.HasValue)
            {
                rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
            }
        }
    }
}
