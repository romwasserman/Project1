using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public CharacterController CC;
	public float moveSpeed;
	public float Gravity = -9f;
	public float jumpSpeed;
	public float verticalSpeed;
    private void Update()
    {
		Vector3 movement = Vector3.zero;

		float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
		
		float sideMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		
		movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

		if (CC.isGrounded)
		{
			verticalSpeed = 0f;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				verticalSpeed = jumpSpeed;
			}
		}

		verticalSpeed += (Gravity * Time.deltaTime);
		movement += (transform.up * verticalSpeed * Time.deltaTime);

		CC.Move(movement);
	}
}
