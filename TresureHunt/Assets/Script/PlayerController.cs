 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	//counting the points gained throughout the game
	private int count;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	//The text where the score will be displayed
	public Text counttext; 
	// The player's default position
	Vector3 defaultPos;



	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer> ();
		count = 0; 
		SetCountText(); 
	}

	//Player movement, horizontal and vertcal
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");



		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//rb.velocity = Vector2.right * moveHorizontal * speed;
		rb.AddForce (movement * speed);

		if (Input.GetButtonDown("Jump")){
			//rb.AddForce(Vector2.up * 10000f);
			rb.velocity= new Vector2(0, 7);
		}
		// Player will change his direction 
		sr.flipX = rb.velocity.x < 0;


	}
	//Player hit 2D Objects to gain points and end game 
	void OnTriggerEnter2D (Collider2D c) {
		//player hit sprite resources to gain points 
		if (c.tag == "points") {
			Destroy (c.gameObject);
			count = count +1;
			SetCountText(); 
		}
		//Player hit sprite resources'treasure' to finish the game and display Menu scene
		if (c.tag == "tresure") {
			Destroy (c.gameObject);
			SceneManager.LoadScene ("Menu"); 
		
		}

		if (c.tag == "timer") {
			Destroy (c.gameObject);
			GameObject.FindObjectOfType <TimerController> ().AddTime ();
		}
	}

	//When the player disappears, reset him 
	void OnBecameInvisible () {

		transform.position = defaultPos;
		transform.rotation = Quaternion.identity;

	}

	// The points obtained will be displayed in this text label
	void SetCountText(){
		counttext.text = "Score: " + count.ToString();

	
	} 

}


