using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name.Contains ("Ball")) {
			Destroy (col.gameObject, 0f);
		}
		GM.instance.LoseLife ();
	}
}
