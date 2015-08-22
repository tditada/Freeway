﻿using UnityEngine;
using System.Collections;

public class FireCars : MonoBehaviour {
	public float fireTime = 60f;

	void Start () {
		//InvokeRepeating ("Fire", fireTime, fireTime);
	}

	public void Fire (GenericPoolScript pool) {
		//GenericPoolScript pool = new GenericPoolScript();
		GameObject obj = pool.getPooledObject ();

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);

	}
}
