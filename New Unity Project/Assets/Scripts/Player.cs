using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;

    private bool m_Grounded = true;

    [SerializeField] float jumpForce;
    [SerializeField] float rotateSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        Rotate();
    }

    private void Rotate()
    {
        playerRb.transform.Rotate(Vector3.up * Time.deltaTime * Input.GetAxis("Horizontal") * rotateSpeed);
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerRb.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * runSpeed);
        }
        else
        {
            playerRb.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * walkSpeed);
        }
        
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_Grounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            m_Grounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            m_Grounded = true;
        }
    }
}
