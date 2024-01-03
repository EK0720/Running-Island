using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float initialSpeed = 50f;
    public float acceleration = 10f;
    private float currentSpeed;
    private bool isMoving = false;

    private void Start()
    {
        currentSpeed = initialSpeed;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
            currentSpeed -= acceleration * Time.deltaTime;
            if (currentSpeed <= 0)
            {
                isMoving = false;
                DeactivateTrain();
            }
        }
    }

    public void ActivateTrain()
    {
        isMoving = true;
        currentSpeed = initialSpeed;
        gameObject.SetActive(true);
    }

    private void DeactivateTrain()
    {
        gameObject.SetActive(false);
    }
}