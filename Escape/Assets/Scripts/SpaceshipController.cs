using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField]
    float thrustersForce = 650.0f;

    [SerializeField]
    float rotationSpeed = 25.0f;

    Rigidbody rb;

    bool isThrusterPressed;

    float inputX;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.Log(isThrusterPressed);
        HandleInputs();
    }

    private void FixedUpdate()
    {
        HandleRotation();
        HandleThrusters();
    }

    void HandleRotation()
    {
        if (!isThrusterPressed)
        {
            return;
        }

        Vector3 rotation = Vector3.forward * -inputX * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }

    void HandleThrusters() {
        if (!isThrusterPressed)
        {
            return;
        }

        Vector3 direction = Vector3.up * thrustersForce * Time.fixedDeltaTime;
        rb.AddRelativeForce(direction, ForceMode.Force);
    
    }

    void HandleInputs() {
        inputX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Jump"))
        {
            isThrusterPressed = true;
        }
        else { 
            isThrusterPressed = false;
        }
    }
}
