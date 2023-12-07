using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;

    public float speed;

    public float rotationSpeed = 10;
    private float m_CameraVerticalAngle;

    private Vector3 m_Movement = Vector3.zero;
    private Vector3 m_RotationInput = Vector3.zero;


    private void Update()
    {
        _Movement();
        _LookAt();
    }

    private void _Movement()
    {
        m_Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(m_Movement * speed * Time.deltaTime);
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


    