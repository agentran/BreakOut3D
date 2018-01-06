using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	public float ballIntialVelocity = 600f;
	private Rigidbody rb;
	private bool ballInPlay;


	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		
		if (Input.GetButtonDown ("Fire1") && ballInPlay == false) {
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballIntialVelocity, ballIntialVelocity, 0));
		}
	}

} 
	