using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    float MoveSpeed;
    public float Xspin = 20f;
    public Rigidbody rb;
    public Transform camTransform;
    public float camRotation = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);

        //Rotate player on the Y axis
        transform.Rotate(transform.up * 2f * Input.GetAxis("Mouse X"));
        camTransform.Rotate(Vector3.left * 2f * Input.GetAxis("Mouse Y"), Space.Self);

        //Rotate cameron on X axis - local

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        rb = GetComponent<Rigidbody>();

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
        }
    }
}
