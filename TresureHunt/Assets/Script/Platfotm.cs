using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platfotm : MonoBehaviour {

	private Vector3 positionA;
	private Vector3 positionB;
	private Vector3 nextPos;
	[SerializeField]
	private float speed;
	[SerializeField]
	private Transform childTrans;
	[SerializeField]
	private Transform transformB;


	// Use this for initialization
	void Start () {
		positionA = childTrans.localPosition;
		positionB = transformB.localPosition;
		nextPos = positionB;
	}
	
	// Update is called once per frame
	void Update () {
		// The function Move is implemeted to work in Update()
		Move ();
		
	}
	//Platform movement 
	private void Move(){
		childTrans.localPosition = Vector3.MoveTowards (childTrans.localPosition, nextPos, speed * Time.deltaTime);
		if (Vector3.Distance(childTrans.localPosition,nextPos)<= 0.1){
			ChangeDest ();
		}
	}
	//The platform will change it's destination
	private void ChangeDest (){
		nextPos = nextPos != positionA ? positionA : positionB;

	}
}
