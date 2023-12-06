using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;

    public float speed;

    public Rigidbody playerRb;

    private float horizontalMovement;
    private float frontMovement;

    Vector3 offset = new Vector3(0, 2, 0);

    private void Start()
    {
        playerRb = playerRb.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        _Movement();
        mainCamera.transform.position = transform.position + offset;
    }

    private void _Movement()
    {
        
        horizontalMovement = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalMovement * speed * Time.deltaTime);
        //playerRb.AddForce(Vector3.right * horizontalMovement * speed * Time.deltaTime); //with rB


        frontMovement = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * frontMovement * speed * Time.deltaTime);
        //playerRb.AddForce(Vector3.forward * frontMovement * speed * Time.deltaTime); //with rB
    }

}


    