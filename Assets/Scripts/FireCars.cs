using UnityEngine;
using System.Collections;

public class FireCars : MonoBehaviour {

	public float fireTime = 1f;
	public GenericPoolScript pool;
	float actualTime;

	void Start () {
		actualTime = 0;
		pool = this.GetComponent<GenericPoolScript> ();
	}

	void Update(){
		actualTime += Time.deltaTime;
		if (actualTime>fireTime) {
			float value = Random.value;
			if(value>0.985){
				Fire ();
				actualTime=0;
			}
		}
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
