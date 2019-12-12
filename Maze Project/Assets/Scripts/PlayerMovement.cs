using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float baseSpeed;

    Rigidbody rb;

    public float time;
    float directionX;
    float directionZ;
    float currentSpeed;

    private void Start()
    {
        time = 0f;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        directionZ = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;

        if(directionZ != 0f || directionX != 0f)
        {
            currentSpeed = Mathf.Sqrt(Mathf.Pow(baseSpeed, 2) / (Mathf.Pow(directionX, 2) + (Mathf.Pow(directionZ, 2))));
        }
        else
        {
            currentSpeed = 0f;
        }
        rb.velocity = new Vector3(directionX * currentSpeed, 0f, directionZ * currentSpeed);
    }

    public float GetTimerTime()
    {
        return time;
    }
}
