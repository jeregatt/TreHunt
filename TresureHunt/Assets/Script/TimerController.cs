using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

	// This is the game time limit
	public float timeLimit = 30f;

	//Wwhen did this level start?
	protected float endTime;

	// The Time Limit Text
	public Text timeLimitText;




	void Start () {
	
		// Time.time = the time since the game was launched
		// what time should the level end?
		// (assuming the level can't be paused)
		endTime = Time.time + timeLimit;

	}


	void Update () {

		// How much time is left?
		int timeLeft = Mathf.CeilToInt(endTime - Time.time);

		// Write the time left to the screen
		timeLimitText.text = " " + timeLeft;

		// Change the scene only when the time is up
		if (timeLeft <= 0) {
			SceneManager.LoadScene ("GameOver");
		}

		if (timeLeft <= 10) {
			timeLimitText.fontSize = 60;
		}

	}

	public void AddTime()
	{
		endTime += 10;
	}

}
