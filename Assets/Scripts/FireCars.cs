using UnityEngine;
using System.Collections;

public class FireCars : MonoBehaviour {
	public float fireTime = 60f;

	void Start () {
		InvokeRepeating ("Fire", fireTime, fireTime);
	}

	void Fire () {
		GameObject obj = GenericPoolScript.singlePool.getPooledObject();

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);

	}
}
