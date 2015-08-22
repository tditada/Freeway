using UnityEngine;
using System.Collections;

public class FireCars : MonoBehaviour {

	public float fireTime = 1f;
	public GenericPoolScript pool;

	void Start () {
		pool = this.GetComponent<GenericPoolScript> ();
		InvokeRepeating ("Fire", fireTime, fireTime);
	}

	public void Fire () {
		GameObject obj = pool.getPooledObject ();
		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);
		
	}
}
