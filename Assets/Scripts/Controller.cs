using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

	public float paddleSpeed = 1f;


	private Vector3 playerPos = new Vector3 (0, -5f, 0);

	void Update ()
	{
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * paddleSpeed);

		if (Input.touchCount == 1) {
			Touch touch = Input.GetTouch (0);
			if (touch.position.x > Screen.width / 2) {
				xPos = transform.position.x + paddleSpeed;
			} else {
				xPos = transform.position.x - paddleSpeed;
			}
			xPos = -15f + 30 * touch.position.x / Screen.width;
		}
		playerPos = new Vector3 (Mathf.Clamp (xPos, -12.5f, 12.5f), -5f, 0f);
		transform.position = playerPos;
		Debug touchCount;
	}
}