using UnityEngine;
using System.Collections;

public class CarRow : MonoBehaviour {

	public float fireTime = 1f;
	public GenericPoolScript pool;

	// Use this for initialization
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
