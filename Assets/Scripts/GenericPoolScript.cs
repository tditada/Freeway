using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericPoolScript : MonoBehaviour {

	public static GenericPoolScript singlePool;
	public GameObject pooledObject;
	public float pooledAmount = 10f;
	public bool willGrow = true;

	List<GameObject> pooledObjects;

	void Awake(){
		singlePool = this;
	}

	void Start () {
		pooledObjects = new List<GameObject> ();
		for (int i=0; i< pooledAmount; i++) {
			GameObject obj = Instantiate (pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	public GameObject getPooledObject(){
		for (int i=0; i< pooledObjects.Count; i++) {
			if(!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}
		}
		if (willGrow) {
			GameObject obj = Instantiate (pooledObject);
			obj.SetActive (true);
			pooledObjects.Add (obj);
			return obj;
		}

		return null;
	}
}