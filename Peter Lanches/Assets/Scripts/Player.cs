using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float LANE_DISTANCE = 2.0f;
    private const float TURN_SPEED = 0.05f;
    private CharacterController controller;
    private MobileInputs Input;
   

    private float jumpForce = 6.0f;
    private float gravity = 12.0f;
    private float verticalVelocity;
    private float speed = 7.0f;
    private int desiredLane = 1;

    private void Start()
    {
        Time.timeScale = 1f;
        controller = GetComponent<CharacterController>();
        Input = GameObject.FindObjectOfType<MobileInputs>();
    }

    private void Update()
    {
        if (MobileInputs.Instance.SwipeLeft)
            MoveLane(false);
        if (MobileInputs.Instance.SwipeRight)
            MoveLane(true);

        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
            targetPosition += Vector3.left * LANE_DISTANCE;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * LANE_DISTANCE;

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;

        bool isGrounded = IsGrounded();

        if (isGrounded)
        {
            verticalVelocity = -0.1f;

            if (MobileInputs.Instance.SwipeUp)
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);
            if (MobileInputs.Instance.SwipeDown)
            {
                verticalVelocity = -jumpForce;
            }
        }

        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);


    }
    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(new Vector3(controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f, controller.bounds.center.z), Vector3.down);
        return Physics.Raycast(groundRay, 0.2f + 0.1f);
    }
}