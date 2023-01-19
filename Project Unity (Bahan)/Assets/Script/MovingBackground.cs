using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour {



	public float speed;
	private float x;
	public float Destination;
	public float prevPlace;




	// Use this for initialization
	void Start () {
		//prevPlace = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {


		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= Destination){

			
			x = prevPlace;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}
