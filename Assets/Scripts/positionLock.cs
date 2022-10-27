using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionLock : MonoBehaviour {
	public Transform target;
	// Use this for initialization

	public bool x;
	public bool y;
	public bool z;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (x&y&z || !x&!y&!z) {
			this.transform.position = target.transform.position;
		} else {
			Vector3 temp = new Vector3();
			temp.x = ((!x)?this.transform.position.x:target.transform.position.x);
			temp.y = ((!y)?this.transform.position.y:target.transform.position.y);
			temp.z = ((!z)?this.transform.position.z:target.transform.position.z);
			this.transform.position = temp;
		}
	}
}
