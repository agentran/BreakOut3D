using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour 
{
	public GameObject brickParticle;

	void OnCollisionEnter (Collision col)
	{
		Instantiate (brickParticle, transform.position, Quaternion.identity);
		GM.instance.DestroyBrick (); //game mangager lowering the int of the bricks
		Destroy(gameObject);
	}


}