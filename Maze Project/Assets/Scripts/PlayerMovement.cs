using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float baseSpeed;

    Rigidbody rb;

    float directionX;
    float directionZ;
    float currentSpeed;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        directionZ = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        currentSpeed = Mathf.Sqrt(Mathf.Pow(directionX * baseSpeed, 2) + Mathf.Pow(directionZ * baseSpeed, 2));
        Debug.Log(currentSpeed);
        rb.velocity = new Vector3(directionX * currentSpeed, 0f, directionZ * currentSpeed);
    }
}
