using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public float MouseSensitivity;
	public Transform CamTransform;
	public GameObject player;
	private float camRotation = 0f;

	public float damage = 10f;

	private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update()
    {
		float mouseInputY = Input.GetAxis("Mouse Y") * MouseSensitivity;
		camRotation -= mouseInputY;
		camRotation = Mathf.Clamp(camRotation, -90f, 90f);
		CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

		float mouseInputX = Input.GetAxis("Mouse X") * MouseSensitivity;
		transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX, 0f));

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
			{
				Enemy hitEnemy = hit.collider.GetComponent<Enemy>();

				if (hitEnemy != null)
				{
					Debug.DrawLine(CamTransform.position + new Vector3(0f, -1f, 0f), hit.point, Color.green, 1f);
					Debug.Log(hit.collider.gameObject.name);
					Enemy target = hit.transform.GetComponent<Enemy>();
					if (target != null)
                    {
						target.TakeDamage(damage);
                    }

				}
				else
				{
					Debug.DrawRay(CamTransform.position + new Vector3(0f, -1f, 0f), CamTransform.forward * 100f, Color.red, 1f);
				}



			}

		}

		}
	}
