using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public float speed;
	public Transform target;

	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position+target.forward* speed * Time.deltaTime;
	}
}
