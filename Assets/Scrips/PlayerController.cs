using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;

    public float walkSpeed;
    public float runSpeed;
    public float jumpHeight = 2.0f;
    public float gravityScale = -20f;

    public float rotationSpeed = 10f;

    
    private float m_CameraVerticalAngle;
    private Vector3 m_MovementInput = Vector3.zero;
    private Vector3 m_RotationInput = Vector3.zero;
    private CharacterController characterController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _Movement();
        _LookAt();
    }

    private void _Movement()
    {
        if (characterController.isGrounded)
        {
            m_MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _Sprint();
            _Jump();
        }

        m_MovementInput.y += gravityScale * Time.deltaTime;
        characterController.Move(m_MovementInput * Time.deltaTime);
    }

    private void _Sprint()
    {
        if (Input.GetButton("Sprint"))
        {
            m_MovementInput = transform.TransformDirection(m_MovementInput) * runSpeed;
        }
        else
        {
            m_MovementInput = transform.TransformDirection(m_MovementInput) * walkSpeed;
        }
    }

    private void _Jump()
    {
        if (Input.GetButton("Jump"))
        {
            m_MovementInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
        }
    }

    private void _LookAt()
    {
        m_RotationInput.x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        m_RotationInput.y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        m_CameraVerticalAngle += m_RotationInput.y;
        m_CameraVerticalAngle = Mathf.Clamp(m_CameraVerticalAngle, -70, 70);

        transform.Rotate(Vector3.up * m_RotationInput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-m_CameraVerticalAngle, 0, 0);
    }

}


    