using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// What object are we following
	public Transform followObject;

	// How smooth is the animation?
	float smoothing = 5f;

	// How far away is the camera from the object?
	Vector3 offset;

	float duration = 30f;




	// When the script starts, find out its offset
	void Start () {

		offset = transform.position - followObject.position;
		Camera.main.backgroundColor = Color.cyan;

	}


	// Move the camera according to physics
	void FixedUpdate () {

		Vector3 targetPos = followObject.position + offset;
		if (targetPos.y < 0f) {
			targetPos.y = 0f;
		}

		transform.position = Vector3.Lerp (transform.position,targetPos, smoothing * Time.deltaTime);


	}

	void Update()
	{
		//Camera background, change colour
		Camera.main.backgroundColor = Color.Lerp (Camera.main.backgroundColor, Color.black, Time.deltaTime/duration);


	}


}
